using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Transport
    {
        public Transport()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid TransportId { get; set; }
        public bool OneWay { get; set; }
        public string StartLocation { get; set; } = null!;
        public string EndLocation { get; set; } = null!;
        public double Price { get; set; }
        public Guid TransportTypeId { get; set; }

        public virtual TransportType TransportType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
