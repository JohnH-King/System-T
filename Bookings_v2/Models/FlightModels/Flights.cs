using static Bookings.Models.FlightModels.FlightPackages;

namespace Bookings.Models.FlightModels
{
    public class Flights
    {
        public int Id { get; set; }
        public Departure? departure { get; set; }
        public Arrival? arrival { get; set; }
        public string? carrierCode { get; set; }
        public int numberOfStops { get; set; }
    }
}

