using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;
using ThAmCo.Catering.Models;

namespace ThAmCo.Catering.Controllers
{
    public class MenuFoodItemsController : Controller
    {
        private readonly CateringDbContext _context;

        public MenuFoodItemsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: MenuFoodItems
        public async Task<IActionResult> Index()
        {
            var cateringDbContext = _context.MenuFoodItem.Include(m => m.FoodItem).Include(m => m.Menu);
            return View(await cateringDbContext.ToListAsync());
        }

        // GET: MenuFoodItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuFoodItem = await _context.MenuFoodItem
                .Include(m => m.FoodItem)
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.MenuFoodItemId == id);
            if (menuFoodItem == null)
            {
                return NotFound();
            }

            return View(menuFoodItem);
        }

        // GET: MenuFoodItems/Create
        public IActionResult Create()
        {
            ViewData["FoodItemId"] = new SelectList(_context.FoodItem, "FoodItemId", "FoodItemId");
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "MenuId");
            return View();
        }

        // POST: MenuFoodItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuFoodItemId,MenuId,FoodItemId")] MenuFoodItem menuFoodItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuFoodItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodItemId"] = new SelectList(_context.FoodItem, "FoodItemId", "FoodItemId", menuFoodItem.FoodItemId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "MenuId", menuFoodItem.MenuId);
            return View(menuFoodItem);
        }

        // GET: MenuFoodItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuFoodItem = await _context.MenuFoodItem.FindAsync(id);
            if (menuFoodItem == null)
            {
                return NotFound();
            }
            ViewData["FoodItemId"] = new SelectList(_context.FoodItem, "FoodItemId", "FoodItemId", menuFoodItem.FoodItemId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "MenuId", menuFoodItem.MenuId);
            return View(menuFoodItem);
        }

        // POST: MenuFoodItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuFoodItemId,MenuId,FoodItemId")] MenuFoodItem menuFoodItem)
        {
            if (id != menuFoodItem.MenuFoodItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuFoodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuFoodItemExists(menuFoodItem.MenuFoodItemId))
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
            ViewData["FoodItemId"] = new SelectList(_context.FoodItem, "FoodItemId", "FoodItemId", menuFoodItem.FoodItemId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "MenuId", menuFoodItem.MenuId);
            return View(menuFoodItem);
        }

        // GET: MenuFoodItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuFoodItem = await _context.MenuFoodItem
                .Include(m => m.FoodItem)
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.MenuFoodItemId == id);
            if (menuFoodItem == null)
            {
                return NotFound();
            }

            return View(menuFoodItem);
        }

        // POST: MenuFoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuFoodItem = await _context.MenuFoodItem.FindAsync(id);
            _context.MenuFoodItem.Remove(menuFoodItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItem.Any(e => e.MenuFoodItemId == id);
        }
    }
}
