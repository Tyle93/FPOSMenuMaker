using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class CorporateMessage
    {
        public Guid CorporateMessageId { get; set; }
        public int State { get; set; }
        public string? Url { get; set; }
        public string ApplicationName { get; set; } = null!;
    }
}
