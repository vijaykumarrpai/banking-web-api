using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class TransactionModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}