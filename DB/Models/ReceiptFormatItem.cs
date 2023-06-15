using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class ReceiptFormatItem
    {
        public Guid ReceiptFormatItemId { get; set; }
        public Guid ReceiptFormatId { get; set; }
        public string ReceiptName { get; set; } = null!;
        public string? Format { get; set; }

        public virtual ReceiptFormat ReceiptFormat { get; set; } = null!;
    }
}
