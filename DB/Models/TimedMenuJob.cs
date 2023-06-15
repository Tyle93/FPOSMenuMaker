using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class TimedMenuJob
    {
        public Guid TimedMenuJobId { get; set; }
        public Guid TimedMenuId { get; set; }
        public int JobCode { get; set; }

        public virtual TimedMenu TimedMenu { get; set; } = null!;
    }
}
