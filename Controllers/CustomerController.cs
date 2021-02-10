using BankAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly BankContext _context;
        public CustomerController(BankContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("GetCustomer")]
        public async Task<ActionResult<Customer>> GetCustomer()
        {
            try
            {
                string emailAddress = HttpContext.User.Identity.Name;

                var customer = await _context.Customers.Include(x => x.Accounts)
                                                            .ThenInclude(x => x.AccountBalances)
                                                       .Where(customer => customer.Email == emailAddress).FirstOrDefaultAsync();
                if (customer == null)
                {
                    return NotFound();
                }
                return customer;
            }
            catch (Exception)
            {
                return Ok("Error occured.");
            }

        }

        [HttpPut("DepositAmount")]
        public IActionResult DepositAmount(Transaction transaction)
        {
            try
            {
                AccountBalance accDetail = _context.AccountBalances.Where(x => x.AccountId == transaction.AccountId).FirstOrDefault();
                accDetail.Balance = accDetail.Balance + transaction.Amount;
                accDetail.Type = "Deposit";
                accDetail.Amount = transaction.Amount;
                _context.SaveChanges();
                return Ok($"Amount {transaction.Amount} deposited successfully. Available balance is {accDetail.Balance}");
            }
            catch (Exception)
            {
                return Ok("Error occured while doing Deposit.");
            }
        }

        [HttpPut("WithdrawAmount")]
        public IActionResult WithdrawAmount(Transaction transaction)
        {
            try
            {
                AccountBalance accDetail = _context.AccountBalances.Where(x => x.AccountId == transaction.AccountId).FirstOrDefault();
                accDetail.Balance = accDetail.Balance - transaction.Amount;
                accDetail.Type = "Withdrawal";
                accDetail.Amount = transaction.Amount;
                _context.SaveChanges();
                return Ok($"Amount {transaction.Amount} withdrawn successfully. Available balance is {accDetail.Balance}");
            }
            catch (Exception)
            {
                return Ok("Error occured while doing withdraw.");
            }
        }
    }
}
