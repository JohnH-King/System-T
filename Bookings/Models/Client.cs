using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? CellNumber { get; set; }
    }
}
