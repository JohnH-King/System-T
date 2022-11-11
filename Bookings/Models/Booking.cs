using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Booking
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public Guid AccomodationId { get; set; }
        public Guid FlightId { get; set; }
        public Guid TransactionId { get; set; }
        public double TransactionTotal { get; set; }

        public virtual Accomodation Accomodation { get; set; } = null!;
        public virtual TransportType Flight { get; set; } = null!;
        public virtual Flight Transaction { get; set; } = null!;
        public virtual Transport Transport { get; set; } = null!;
    }
}
