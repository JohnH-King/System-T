using System;
using System.Collections.Generic;

namespace Bookings_v2.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public bool? Approved { get; set; }
    }
}
