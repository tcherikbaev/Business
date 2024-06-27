using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class FinishedProducts
    {
        public FinishedProducts()
        {
            Ingridients = new HashSet<Ingridients>();
            ProdajaProduction = new HashSet<ProdajaProduction>();
            Proizvodstvo = new HashSet<Proizvodstvo>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public byte? Unit { get; set; }
        public decimal? Sum { get; set; }
        public double? Quantity { get; set; }

        public string UnitName;

        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<Ingridients> Ingridients { get; set; }
        public virtual ICollection<ProdajaProduction> ProdajaProduction { get; set; }
        public virtual ICollection<Proizvodstvo> Proizvodstvo { get; set; }
    }
}
