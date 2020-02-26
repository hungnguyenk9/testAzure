using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class CustomerMst
    {
        public int CustId { get; set; }
        public string CustNm { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int? ActiveSt { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
