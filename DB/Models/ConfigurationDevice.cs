using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class ConfigurationDevice
    {
        public Guid ConfigurationDeviceId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public int StoreId { get; set; }
    }
}
