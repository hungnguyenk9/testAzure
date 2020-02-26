using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class OccupationMst
    {
        public int OccId { get; set; }
        public string OccName { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
