using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users) {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user) {
            user.Password = null;
            return user;
        }

         public static IEnumerable<Transaction> WithoutAmounts(this IEnumerable<Transaction> transactions) {
            return transactions.Select(y => y.WithoutAmount());
        }

        public static Transaction WithoutAmount(this Transaction transaction) {
            transaction.Amount = 0;
            return transaction;
        }
    }
}