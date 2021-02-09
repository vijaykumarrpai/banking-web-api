namespace BankAPI.Models
{
    public class BalanceDetails
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}
