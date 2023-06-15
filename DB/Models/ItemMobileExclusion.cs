using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class ItemMobileExclusion
    {
        public Guid ItemMobileExclusionId { get; set; }
        public Guid ItemId { get; set; }
        public short EmpId { get; set; }

        public virtual Item Item { get; set; } = null!;
    }
}
