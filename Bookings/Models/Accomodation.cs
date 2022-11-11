using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Accomodation
    {
        public Accomodation()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid AccomodationId { get; set; }
        public bool OneWay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = null!;
        public double Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
