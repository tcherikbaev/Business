using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Bank
    {
        public short Id { get; set; }
        public double? Sum { get; set; }
        public short? SrokInMonths { get; set; }
        public short? ProcentPenya { get; set; }
        public double? Ostatok { get; set; }
    }
}
