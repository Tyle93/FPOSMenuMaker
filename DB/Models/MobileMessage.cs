using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class MobileMessage
    {
        public Guid MobileMessageId { get; set; }
        public string? MessageText { get; set; }
    }
}
