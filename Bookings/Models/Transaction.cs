using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Transaction
    {
        public Guid TransactionId { get; set; }
        public bool Approved { get; set; }
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
