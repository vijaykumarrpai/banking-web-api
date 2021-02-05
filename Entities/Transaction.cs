namespace WebApi.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public int AvailableBalance { get; set; }
    }
}