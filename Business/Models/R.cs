using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class R
    {
        public short Id { get; set; }
        public short RawMaterial { get; set; }
        public double? Amount { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public byte Employee { get; set; }
    }
}
