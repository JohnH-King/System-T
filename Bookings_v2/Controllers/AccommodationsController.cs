using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookings_v2.Models;

namespace Bookings_v2.Controllers
{
    public class AccommodationsController : Controller
    {
        private readonly SystemTContext _context;

        public AccommodationsController(SystemTContext context)
        {
            _context = context;
        }

        // GET: Accommodations
        public async Task<IActionResult> Index()
        {
              return View(await _context.Accommodations.ToListAsync());
        }

        // GET: Accommodations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accommodations == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations
                .FirstOrDefaultAsync(m => m.AccommodationId == id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return View(accommodation);
        }

        // GET: Accommodations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accommodations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccommodationId,StartDate,EndDate,Bookings,Location,Price,ImageId")] Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accommodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accommodation);
        }

        // GET: Accommodations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accommodations == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation == null)
            {
                return NotFound();
            }
            return View(accommodation);
        }

        // POST: Accommodations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccommodationId,StartDate,EndDate,Bookings,Location,Price,ImageId")] Accommodation accommodation)
        {
            if (id != accommodation.AccommodationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accommodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccommodationExists(accommodation.AccommodationId))
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
            return View(accommodation);
        }

        // GET: Accommodations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accommodations == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations
                .FirstOrDefaultAsync(m => m.AccommodationId == id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return View(accommodation);
        }

        // POST: Accommodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accommodations == null)
            {
                return Problem("Entity set 'SystemTContext.Accommodations'  is null.");
            }
            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation != null)
            {
                _context.Accommodations.Remove(accommodation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccommodationExists(int id)
        {
          return _context.Accommodations.Any(e => e.AccommodationId == id);
        }
    }
}
