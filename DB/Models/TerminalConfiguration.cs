using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class TerminalConfiguration
    {
        public Guid TerminalConfigurationId { get; set; }
        public short TerminalNumber { get; set; }
        public DateTime LastUpdate { get; set; }
        public int StoreId { get; set; }
        public string? ConfigurationXml { get; set; }
    }
}
