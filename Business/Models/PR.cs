using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class PR
    {
        public short Id { get; set; }
        public short Production { get; set; }
        public double? Amount { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public byte Employee { get; set; }
    }
}
