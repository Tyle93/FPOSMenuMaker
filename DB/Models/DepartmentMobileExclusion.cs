using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class DepartmentMobileExclusion
    {
        public Guid DepartmentMobileExclusionId { get; set; }
        public Guid DepartmentId { get; set; }
        public short EmpId { get; set; }

        public virtual Department Department { get; set; } = null!;
    }
}
