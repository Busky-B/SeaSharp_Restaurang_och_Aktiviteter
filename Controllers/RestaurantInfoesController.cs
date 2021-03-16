using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeaSharp_Restaurang_och_Aktiviteter.Models;

namespace SeaSharp_Restaurang_och_Aktiviteter.Controllers
{
    public class RestaurantInfoesController : Controller
    {
        private readonly ModelsContext _context;

        public RestaurantInfoesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: RestaurantInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestaurantInfo.ToListAsync());
        }

        // GET: RestaurantInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantInfo = await _context.RestaurantInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantInfo == null)
            {
                return NotFound();
            }

            return View(restaurantInfo);
        }

        // GET: RestaurantInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestaurantInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DayName,Open,Closed")] RestaurantInfo restaurantInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantInfo);
        }

        // GET: RestaurantInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantInfo = await _context.RestaurantInfo.FindAsync(id);
            if (restaurantInfo == null)
            {
                return NotFound();
            }
            return View(restaurantInfo);
        }

        // POST: RestaurantInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DayName,Open,Closed")] RestaurantInfo restaurantInfo)
        {
            if (id != restaurantInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantInfoExists(restaurantInfo.Id))
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
            return View(restaurantInfo);
        }

        // GET: RestaurantInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantInfo = await _context.RestaurantInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantInfo == null)
            {
                return NotFound();
            }

            return View(restaurantInfo);
        }

        // POST: RestaurantInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantInfo = await _context.RestaurantInfo.FindAsync(id);
            _context.RestaurantInfo.Remove(restaurantInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantInfoExists(int id)
        {
            return _context.RestaurantInfo.Any(e => e.Id == id);
        }
    }
}
