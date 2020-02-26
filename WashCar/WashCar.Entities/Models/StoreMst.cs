using System;
using System.Collections.Generic;

namespace WashCar.Entities.Models
{
    public partial class StoreMst
    {
        public int StoreId { get; set; }
        public string StoreNm { get; set; }
        public string Infos { get; set; }
        public string Services { get; set; }
        public int? ActiveSt { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
