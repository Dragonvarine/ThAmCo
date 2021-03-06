using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;
using ThAmCo.Catering.Models;

namespace ThAmCo.Catering.Controllers
{
    public class FoodBookingsController : Controller
    {
        private readonly CateringDbContext _context;

        public FoodBookingsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: FoodBookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodBooking.ToListAsync());
        }

        // GET: FoodBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodBooking = await _context.FoodBooking
                .FirstOrDefaultAsync(m => m.FoodBookingId == id);
            if (foodBooking == null)
            {
                return NotFound();
            }

            return View(foodBooking);
        }

        // GET: FoodBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodBookingId,ClientReferenceId,NumberOfGuests,MenuId")] FoodBooking foodBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodBooking);
        }

        // GET: FoodBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodBooking = await _context.FoodBooking.FindAsync(id);
            if (foodBooking == null)
            {
                return NotFound();
            }
            return View(foodBooking);
        }

        // POST: FoodBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodBookingId,ClientReferenceId,NumberOfGuests,MenuId")] FoodBooking foodBooking)
        {
            if (id != foodBooking.FoodBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodBookingExists(foodBooking.FoodBookingId))
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
            return View(foodBooking);
        }

        // GET: FoodBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodBooking = await _context.FoodBooking
                .FirstOrDefaultAsync(m => m.FoodBookingId == id);
            if (foodBooking == null)
            {
                return NotFound();
            }

            return View(foodBooking);
        }

        // POST: FoodBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodBooking = await _context.FoodBooking.FindAsync(id);
            _context.FoodBooking.Remove(foodBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodBookingExists(int id)
        {
            return _context.FoodBooking.Any(e => e.FoodBookingId == id);
        }
    }
}
