using System;
using System.Collections.Generic;

namespace AspCoreModule2.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            PassInTrip = new HashSet<PassInTrip>();
        }

        public int IdPsg { get; set; }
        public string Name { get; set; }

        public ICollection<PassInTrip> PassInTrip { get; set; }
    }
}
