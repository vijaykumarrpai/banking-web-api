using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BankAPI.Models
{
    public partial class AccountDetail
    {
        public int AccBalanceId { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public int? AccountNumber { get; set; }

        public virtual Account Account { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
