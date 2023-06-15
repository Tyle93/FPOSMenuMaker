using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class Graphic
    {
        public Guid GraphicId { get; set; }
        public int StoreId { get; set; }
        public string GraphicName { get; set; } = null!;
        public byte[] DibData { get; set; } = null!;
    }
}
