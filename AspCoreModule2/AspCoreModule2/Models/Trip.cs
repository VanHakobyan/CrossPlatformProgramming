using System;
using System.Collections.Generic;

namespace AspCoreModule2.Models
{
    public partial class Trip
    {
        public Trip()
        {
            PassInTrip = new HashSet<PassInTrip>();
        }

        public int TripNo { get; set; }
        public int IdComp { get; set; }
        public string Plane { get; set; }
        public string TownFrom { get; set; }
        public string TownTo { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime TimeIn { get; set; }

        public Company IdCompNavigation { get; set; }
        public ICollection<PassInTrip> PassInTrip { get; set; }
    }
}
