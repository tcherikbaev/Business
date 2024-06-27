using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Ingridients
    {
        public short Id { get; set; }
        public short? Product { get; set; }
        public short RawProduct { get; set; }
        public double? Quntatity { get; set; }
        public string ProductName;
        public string RawName;

        public virtual FinishedProducts ProductNavigation { get; set; }
        public virtual RawMaterials RawProductNavigation { get; set; }
    }
}
