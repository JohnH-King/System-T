using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class TransportType
    {
        public TransportType()
        {
            Bookings = new HashSet<Booking>();
            Transports = new HashSet<Transport>();
        }

        public Guid TransportTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Transport> Transports { get; set; }
    }
}
