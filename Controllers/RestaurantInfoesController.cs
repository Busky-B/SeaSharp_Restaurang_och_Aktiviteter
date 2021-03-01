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
    public class RestaurantInfoesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public RestaurantInfoesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantInfo>>> GetRestaurantInfo()
        {
            return await _context.RestaurantInfo.ToListAsync();
        }

        // GET: api/RestaurantInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantInfo>> GetRestaurantInfo(int id)
        {
            var restaurantInfo = await _context.RestaurantInfo.FindAsync(id);

            if (restaurantInfo == null)
            {
                return NotFound();
            }

            return restaurantInfo;
        }

        // PUT: api/RestaurantInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantInfo(int id, RestaurantInfo restaurantInfo)
        {
            if (id != restaurantInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantInfoExists(id))
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

        // POST: api/RestaurantInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantInfo>> PostRestaurantInfo(RestaurantInfo restaurantInfo)
        {
            _context.RestaurantInfo.Add(restaurantInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantInfo", new { id = restaurantInfo.Id }, restaurantInfo);
        }

        // DELETE: api/RestaurantInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantInfo(int id)
        {
            var restaurantInfo = await _context.RestaurantInfo.FindAsync(id);
            if (restaurantInfo == null)
            {
                return NotFound();
            }

            _context.RestaurantInfo.Remove(restaurantInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantInfoExists(int id)
        {
            return _context.RestaurantInfo.Any(e => e.Id == id);
        }
    }
}
