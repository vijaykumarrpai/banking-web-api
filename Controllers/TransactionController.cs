using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [AllowAnonymous]
        [HttpPost("transaction")]
        public async Task<IActionResult> Authenticate([FromBody]TransactionModel model)
        {
            var transaction = await _transactionService.Transaction(model.Type, model.Amount);

            if (transaction == null)
                return BadRequest(new { message = "Wrong choice" });

            return Ok(transaction);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionService.GetAll();
            return Ok(transactions);
        }
    }
}
