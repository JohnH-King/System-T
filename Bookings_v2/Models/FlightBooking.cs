using System;
using System.Collections.Generic;

namespace Bookings_v2.Models
{
    public partial class FlightBooking
    {
        public int FlightId { get; set; }
        public bool? OneWay { get; set; }
        public string? DepartureDate { get; set; }
        public string? ReturnDate { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }
        public string? Cost { get; set; }
        public int? ImageId { get; set; }
    }
}
