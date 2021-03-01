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
    public class MenuCategoriesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public MenuCategoriesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/MenuCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuCategory>>> GetMenuCategory()
        {
            var mc = _context.MenuCategory.Include(i => i.Menu);
            return await mc.ToListAsync();
        }

        // GET: api/MenuCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuCategory>> GetMenuCategory(int id)
        {
            var menuCategory = await _context.MenuCategory.FindAsync(id);

            if (menuCategory == null)
            {
                return NotFound();
            }

            return menuCategory;
        }

        // PUT: api/MenuCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuCategory(int id, MenuCategory menuCategory)
        {
            if (id != menuCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuCategoryExists(id))
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

        // POST: api/MenuCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuCategory>> PostMenuCategory(MenuCategory menuCategory)
        {
            _context.MenuCategory.Add(menuCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuCategory", new { id = menuCategory.Id }, menuCategory);
        }

        // DELETE: api/MenuCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuCategory(int id)
        {
            var menuCategory = await _context.MenuCategory.FindAsync(id);
            if (menuCategory == null)
            {
                return NotFound();
            }

            _context.MenuCategory.Remove(menuCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuCategoryExists(int id)
        {
            return _context.MenuCategory.Any(e => e.Id == id);
        }
    }
}
