using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class DinePointJobCode
    {
        public int JobCodeIndex { get; set; }
        public int StoreId { get; set; }
        public string JobCodeName { get; set; } = null!;
    }
}
