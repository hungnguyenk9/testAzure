using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class ServiceMst
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDsc { get; set; }
        public decimal? ServiceUp { get; set; }
        public int? ServiceSt { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
