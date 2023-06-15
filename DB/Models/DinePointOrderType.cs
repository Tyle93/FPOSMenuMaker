using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class DinePointOrderType
    {
        public int OrderTypeIndex { get; set; }
        public int StoreId { get; set; }
        public string? OrderType { get; set; }
        public int ForgiveTax { get; set; }
    }
}
