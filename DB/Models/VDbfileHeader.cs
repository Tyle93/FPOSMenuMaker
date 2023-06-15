using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class VDbfileHeader
    {
        public Guid DbfileId { get; set; }
        public int FileType { get; set; }
        public DateTime FileDate { get; set; }
        public string FileName { get; set; } = null!;
    }
}
