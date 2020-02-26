using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? OrderTid { get; set; }
        public int? CustId { get; set; }
        public int? StoreId { get; set; }
        public string Services { get; set; }
        public decimal? Amount { get; set; }
        public int? PaymentMethod { get; set; }
        public int? OrderSt { get; set; }
        public DateTime? CreateDt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateDt { get; set; }
        public int? UpdateBy { get; set; }
    }
}
