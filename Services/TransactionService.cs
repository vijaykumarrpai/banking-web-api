using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ITransactionService
    {
        Task<Transaction> Transaction(string type, int amount);
        Task<IEnumerable<Transaction>> GetAll();
    }

    public class TransactionService : ITransactionService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Transaction> _transactions = new List<Transaction>
        {
            new Transaction { Id = 1, Type = "Deposit", Amount = 500, AvailableBalance = 1000 },
            new Transaction { Id = 2, Type = "Withdraw", Amount = 200, AvailableBalance = 500 }
        };

        public async Task<Transaction> Transaction(string type, int amount)
        {
            var transaction = await Task.Run(() => _transactions.SingleOrDefault(x => x.Type == type && x.Amount == amount));

            // return null if user not found
            if (transaction == null)
                return null;

            // authentication successful so return user details without password
            return transaction.WithoutAmount();
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await Task.Run(() => _transactions.WithoutAmounts());
        }
    }
}