using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Doljnost
    {
        public Doljnost()
        {
            Employees = new HashSet<Employees>();
        }

        public byte Id { get; set; }
        public string Doljnost1 { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
