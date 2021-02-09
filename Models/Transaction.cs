namespace BankAPI.Models
{
    public class Transaction
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public int Amount { get; set; }
    }
}
