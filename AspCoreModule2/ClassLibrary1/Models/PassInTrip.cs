using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class PassInTrip
    {
        public int TripNo { get; set; }
        public DateTime Date { get; set; }
        public int IdPsg { get; set; }
        public string Place { get; set; }

        public Passenger IdPsgNavigation { get; set; }
        public Trip TripNoNavigation { get; set; }
    }
}
