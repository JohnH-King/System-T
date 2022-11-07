using System;
using System.Collections.Generic;

namespace Bookings.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public bool? Approved { get; set; }
    }
}
