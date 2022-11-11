using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookings.Models;
using Bookings.Classes;
using Bookings.Models.FlightModels;
using Bookings_v2.Models;

namespace Bookings.Controllers
{
    public class FlightsController : Controller
    {
        private readonly SystemTContext _context;

        public FlightsController(SystemTContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,OneWay,DepartureDate,ReturnDate,StartLocation,EndLocation,Cost,ImageId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,OneWay,DepartureDate,ReturnDate,StartLocation,EndLocation,Cost,ImageId")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flights == null)
            {
                return Problem("Entity set 'SystemTContext.Flights'  is null.");
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }

        // GET: Flights
        public async Task<IActionResult> SearchFlights([Bind("OriginLocationCode,DestinationLocationCode,DepartureDate,ReturnDate,Adults")] FlightInformation flightInformation, [FromServices] TravelAPI api)
        {
            FlightInformation flightInformation1 = flightInformation;
            await api.ConnectOAuth();
            FlightPackages results = await api.SearchFlights(flightInformation1);
            List<FlightsOffers> flights = new List<FlightsOffers>();
            if (results.data != null)
            {
                flights = results.data;
            }

            ViewBag.Results = flights;

            return View();
        }

        //Link controler to button

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromBtn(FlightBooking flightBooking)
        {
            Flight flight = new Flight();
            flight.StartLocation = flightBooking.StartLocation;
            flight.EndLocation = flightBooking.EndLocation;
            flight.OneWay = flightBooking.OneWay;

            flight.ReturnDate = DateTime.Parse(flightBooking.ReturnDate);
            flight.DepartureDate = DateTime.Parse(flightBooking.DepartureDate);

            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //redirect na page van john
            return View(flight);
        }
    }
}
