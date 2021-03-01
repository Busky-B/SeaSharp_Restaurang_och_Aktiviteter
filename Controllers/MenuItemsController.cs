using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeaSharp_Restaurang_och_Aktiviteter.Models;

namespace SeaSharp_Restaurang_och_Aktiviteter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public MenuItemsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItems()
        {
            var mi = _context.MenuItems.Include(i => i.MenuCategory).
                ThenInclude(category=>category.Menu);

            return await mi.ToListAsync();
        }

        // GET: api/MenuItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItems>> GetMenuItems(int id)
        {
            var menuItems = await _context.MenuItems.FindAsync(id);

            if (menuItems == null)
            {
                return NotFound();
            }

            return menuItems;
        }

        // PUT: api/MenuItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItems(int id, MenuItems menuItems)
        {
            if (id != menuItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MenuItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuItems>> PostMenuItems(MenuItems menuItems)
        {
         

            _context.MenuItems.Add(menuItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuItems", new { id = menuItems.Id }, menuItems);
        }

        // DELETE: api/MenuItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItems(int id)
        {
            var menuItems = await _context.MenuItems.FindAsync(id);
            if (menuItems == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuItemsExists(int id)
        {
            return _context.MenuItems.Any(e => e.Id == id);
        }
    }
}
