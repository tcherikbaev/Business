using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Year
    {
        public Year()
        {
            Salary = new HashSet<Salary>();
        }

        public short Id { get; set; }

        public virtual ICollection<Salary> Salary { get; set; }
    }
}
