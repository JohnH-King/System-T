using System;
using System.Collections.Generic;

namespace SystemT.Models
{
    public partial class Transaction
    {
        public int? TransactionId { get; set; }
        public bool? Approved { get; set; }
    }
}
