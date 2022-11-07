using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? FllightId { get; set; }
        public int? TransportId { get; set; }
        public int? AccomodationId { get; set; }
        public int? TransactionId { get; set; }
        public int? TransactionTotal { get; set; }
    }
}
