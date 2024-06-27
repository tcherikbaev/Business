using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class RawMaterials
    {
        public RawMaterials()
        {
            Ingridients = new HashSet<Ingridients>();
            ZakupkaRawMaterial = new HashSet<ZakupkaRawMaterial>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public byte? Unit { get; set; }
        public double? Sum { get; set; }
        public double? Quantity { get; set; }

        public string UnitName;
        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<Ingridients> Ingridients { get; set; }
        public virtual ICollection<ZakupkaRawMaterial> ZakupkaRawMaterial { get; set; }
    }
}
