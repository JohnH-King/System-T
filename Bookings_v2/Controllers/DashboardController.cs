using Bookings_v2.Data;
using Bookings_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookings_v2.Models.ViewModels;

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
            //Flights flights = new Flights(_context);
            List<Flight> flights = await _context.Flights.Where(s => s.UserId.Contains(User.Identity.Name.ToString())).ToListAsync();
            
            //var List = _context.Flights.Select(x => new
            //{
            //    id = x.id,
            //    Name = x.Name
            //}).ToList();

            //List<Booking> bookings = await _context.Bookings.Where(s => s.UserId.Contains(User.Identity.Name.ToString())).ToListAsync();
            //IndexViewModel IndexVM = new IndexViewModel()
            //{
            //    Flights = await _context.Flights.Include(m => m.Cost).ToListAsync()
            //    //,
            //    //Category = await _db.Category.ToListAsync(),

            //};

            //if (!String.IsNullOrEmpty(User.Identity.Name.ToString()))
            //{
            //    flights = await flights.Where(s => s.UserId.Contains(User.Identity.Name.ToString()));
            //}
            //List<Flight> flights = await _context.Flights.ToListAsync();

            //return View(flights);

            ViewBag.Flights = flights;


            return View();
        }

        
    }
}
