using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class CheckNumber
    {
        public Guid NextSaleId { get; set; }
        public int StoreId { get; set; }
        public int SaleNumber { get; set; }
        public int TicketNumber { get; set; }
        public DateTime? TicketNumberLastUpdate { get; set; }
    }
}
