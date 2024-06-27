using System;
using System.Collections.Generic;

namespace Business.Models
{
    public partial class Month
    {
        public Month()
        {
            Salary = new HashSet<Salary>();
        }

        public short Id { get; set; }
        public string Month1 { get; set; }

        public virtual ICollection<Salary> Salary { get; set; }
    }
}
