using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Accommodation
    {
        public int AccommodationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Bookings { get; set; }
        public string? Location { get; set; }
        public int? Price { get; set; }
        public int? ImageId { get; set; }
    }
}
