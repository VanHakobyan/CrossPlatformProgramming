using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Company
    {
        public Company()
        {
            Trip = new HashSet<Trip>();
        }

        public int IdComp { get; set; }
        public string Name { get; set; }

        public ICollection<Trip> Trip { get; set; }
    }
}
