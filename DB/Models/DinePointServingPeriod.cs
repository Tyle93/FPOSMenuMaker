using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class DinePointServingPeriod
    {
        public int PeriodIndex { get; set; }
        public int StoreId { get; set; }
        public string? PeriodName { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
    }
}
