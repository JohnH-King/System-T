using System;
using System.Collections.Generic;

namespace SystemT.Models
{
    public partial class Flight
    {
        public int FlightId { get; set; }
        public bool? OneWay { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }
        public string? Cost { get; set; }
        public int? ImageId { get; set; }
    }
}
