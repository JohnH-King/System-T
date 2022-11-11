using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Client
    {
        public Client()
        {
            Transactions = new HashSet<Transaction>();
        }

        public Guid ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CellNumber { get; set; } = null!;
        public Guid ClientLoginId { get; set; }

        public virtual Login ClientLogin { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
