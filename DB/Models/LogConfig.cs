using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class LogConfig
    {
        public Guid LogConfigId { get; set; }
        public short TerminalNumber { get; set; }
        public string Application { get; set; } = null!;
        public byte LogLevel { get; set; }
    }
}
