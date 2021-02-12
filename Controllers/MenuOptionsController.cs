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
    public class MenuOptionsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public MenuOptionsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/MenuOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuOptions>>> GetMenuOptions()
        {
            return await _context.MenuOptions.ToListAsync();
        }

        // GET: api/MenuOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuOptions>> GetMenuOptions(int id)
        {
            var menuOptions = await _context.MenuOptions.FindAsync(id);

            if (menuOptions == null)
            {
                return NotFound();
            }

            return menuOptions;
        }

        // PUT: api/MenuOptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuOptions(int id, MenuOptions menuOptions)
        {
            if (id != menuOptions.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuOptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuOptionsExists(id))
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

        // POST: api/MenuOptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuOptions>> PostMenuOptions(MenuOptions menuOptions)
        {
            _context.MenuOptions.Add(menuOptions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuOptions", new { id = menuOptions.Id }, menuOptions);
        }

        // DELETE: api/MenuOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuOptions(int id)
        {
            var menuOptions = await _context.MenuOptions.FindAsync(id);
            if (menuOptions == null)
            {
                return NotFound();
            }

            _context.MenuOptions.Remove(menuOptions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuOptionsExists(int id)
        {
            return _context.MenuOptions.Any(e => e.Id == id);
        }
    }
}
