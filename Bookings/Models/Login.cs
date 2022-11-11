using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Login
    {
        public Login()
        {
            Clients = new HashSet<Client>();
        }

        public Guid ClientLoginId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string IsAdmin { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
    }
}
