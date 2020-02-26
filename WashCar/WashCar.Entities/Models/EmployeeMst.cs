using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class EmployeeMst
    {
        public int EmpId { get; set; }
        public string EmpNm { get; set; }
        public string MobileNo { get; set; }
        public string UserNm { get; set; }
        public string Password { get; set; }
        public int? StoreId { get; set; }
        public int? OccId { get; set; }
        public int? ActiveSt { get; set; }
        public int? CreateDt { get; set; }
        public int? UpdateDt { get; set; }
    }
}
