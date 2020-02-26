using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class AccountMst
    {
        public int AccountId { get; set; }
        public int? CustId { get; set; }
        public string UserNm { get; set; }
        public string Password { get; set; }
        public int? AccountSt { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
