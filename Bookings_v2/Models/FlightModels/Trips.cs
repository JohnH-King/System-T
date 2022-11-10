using System.Collections.Generic;

namespace Bookings.Models.FlightModels
{
    public class Trips
    {
        public int Id { get; set; }
        public string? duration { get; set; }
        public List<Flights>? segments { get; set; }
    }
}
