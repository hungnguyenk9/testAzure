using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class InfoMst
    {
        public int InfoId { get; set; }
        public string InfoType { get; set; }
        public string InfoContent { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
