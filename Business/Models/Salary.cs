using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public partial class Salary
    {
        public short Id { get; set; }
        public byte? Name { get; set; }
        public short? Year { get; set; }
        public short? Month { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public int? Oklad { get; set; }
        public int? CountStake { get; set; }
        public int? Bonus { get; set; }
        public int? Premia { get; set; }
        public int? Total { get; set; }
        public string EmployeeName;
        public string MonthName;
        public string YearName;
        public virtual Month MonthNavigation { get; set; }
        public virtual Employees NameNavigation { get; set; }
        public virtual Year YearNavigation { get; set; }
    }
}
