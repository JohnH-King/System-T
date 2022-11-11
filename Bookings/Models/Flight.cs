using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid FlightId { get; set; }
        public bool OneWay { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string StartLocation { get; set; } = null!;
        public string EndLocation { get; set; } = null!;
        public double Cost { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
