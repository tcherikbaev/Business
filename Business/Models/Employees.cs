using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Employees
    {
        public Employees()
        {
            ProdajaProduction = new HashSet<ProdajaProduction>();
            Proizvodstvo = new HashSet<Proizvodstvo>();
            SalaryNavigation = new HashSet<Salary>();
            ZakupkaRawMaterial = new HashSet<ZakupkaRawMaterial>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public byte? Doljnost { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public int? Telephone { get; set; }

        public string DoljnostName;
        public virtual Doljnost DoljnostNavigation { get; set; }
        public virtual ICollection<ProdajaProduction> ProdajaProduction { get; set; }
        public virtual ICollection<Proizvodstvo> Proizvodstvo { get; set; }
        public virtual ICollection<Salary> SalaryNavigation { get; set; }
        public virtual ICollection<ZakupkaRawMaterial> ZakupkaRawMaterial { get; set; }
    }
}
