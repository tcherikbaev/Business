using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Pp
    {
        public short Id { get; set; }
        public short Product { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }
        public byte Employee { get; set; }
    }
}
