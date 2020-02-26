using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class TempOrder
    {
        public int TempOrdId { get; set; }
        public int? CustId { get; set; }
        public int? StoreId { get; set; }
        public DateTime? TimeCheckin { get; set; }
        public int? CheckinSt { get; set; }
        public int? TimeEstimate { get; set; }
        public DateTime? CreateDt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateDt { get; set; }
        public int? UpdateBy { get; set; }
    }
}
