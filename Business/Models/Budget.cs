using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Budget
    {
        public short Id { get; set; }
        public decimal? SumOfBudget { get; set; }
        public double? PremiaProcent { get; set; }
        public double? Nadbavka { get; set; }
    }
}
