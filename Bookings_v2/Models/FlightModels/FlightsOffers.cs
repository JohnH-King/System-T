using System.Collections.Generic;

namespace Bookings.Models.FlightModels
{
    public class FlightsOffers
    {
        public int Id { get; set; }
        public int numberOfBookableSeats { get; set; }
        public List<Trips>? itineraries { get; set; }
        public Price? price { get; set; }
    }
}
