using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BankAPI.Models
{
    public partial class AccountBalance
    {
        public int AccBalanceId { get; set; }
        public int AccountId { get; set; }
        
        public string Type { get; set; }

        public int Amount { get; set; }
        public int Balance { get; set; }

        public virtual Account Account { get; set; }
    }
}
