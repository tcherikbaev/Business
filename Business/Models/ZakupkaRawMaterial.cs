using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public partial class ZakupkaRawMaterial
    {
        public short Id { get; set; }
        public short RawMaterial { get; set; }
        public double? Amount { get; set; }
        public decimal? Sum { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public byte Employee { get; set; }
        public string RawName;
        public string EmployeeName;

        public virtual Employees EmployeeNavigation { get; set; }
        public virtual RawMaterials RawMaterialNavigation { get; set; }
    }
}
