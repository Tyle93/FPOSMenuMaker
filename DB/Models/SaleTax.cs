using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class SaleTax
    {
        public Guid SaleTaxId { get; set; }
        public Guid SaleId { get; set; }
        public int TaxIndex { get; set; }
        public int WorkTax { get; set; }
        public int OrigionalTax { get; set; }

        public virtual Sale Sale { get; set; } = null!;
    }
}
