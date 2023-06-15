using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class EmployeeHintShown
    {
        public Guid EmployeeHintShownId { get; set; }
        public Guid EmployeeId { get; set; }
        public int HintIndex { get; set; }
    }
}
