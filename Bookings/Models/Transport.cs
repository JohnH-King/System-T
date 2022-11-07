using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Transport
    {
        public int TransportId { get; set; }
        public int? BookingId { get; set; }
        public int? TypeId { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }
        public int? Cost { get; set; }
        public string? ImageId { get; set; }
    }
}
