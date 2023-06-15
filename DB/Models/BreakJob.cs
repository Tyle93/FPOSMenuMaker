using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class BreakJob
    {
        public Guid BreakJobId { get; set; }
        public Guid BreakId { get; set; }
        public int JobCode { get; set; }

        public virtual Break Break { get; set; } = null!;
    }
}
