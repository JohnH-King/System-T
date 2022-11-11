using Bookings_v2.Data;
using Bookings_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookings_v2.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SystemTContext _context;

        public DashboardController(SystemTContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Flight> flights = await _context.Flights.Where(s => s.UserId.Contains(User.Identity.Name.ToString())).ToListAsync();
            List<Transaction> transactions = await _context.Transactions.ToListAsync();           

            ViewBag.Flights = flights;
            ViewBag.Transactions = transactions;
            return View();
        }

        
    }
}
