using System;
using System.Collections.Generic;

namespace Bookings_v2.Models
{
    public partial class Login
    {
        public int ClientLoginId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Admin { get; set; }
    }
}
