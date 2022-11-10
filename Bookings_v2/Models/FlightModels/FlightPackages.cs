using System.Collections.Generic;

namespace Bookings.Models.FlightModels
{
    public class FlightPackages
    {
        public int Id { get; set; }
        public List<FlightsOffers>? data { get; set; }
    }

}
