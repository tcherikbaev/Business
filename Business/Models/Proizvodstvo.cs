using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public partial class Proizvodstvo
    {
        public short Id { get; set; }
        public short Product { get; set; }
        public double? Amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public byte Employee { get; set; }
        public string ProductName;

        public string EmployeeName;
        public virtual Employees EmployeeNavigation { get; set; }
        public virtual FinishedProducts ProductNavigation { get; set; }
    }
}
