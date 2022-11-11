using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookings_v2.Models;

namespace Bookings_v2.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Flight> Flight { get; set; } = null!;
    }
}
