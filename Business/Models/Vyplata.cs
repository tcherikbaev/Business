using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public partial class Vyplata
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Srok { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Oplachivaetsya { get; set; }
        public double? Sum { get; set; }
        public double? Procent { get; set; }
        public double? Procts { get; set; }
        public double? Penya { get; set; }
        public double? Total { get; set; }
        public double? Ostatok { get; set; }
    }
}
