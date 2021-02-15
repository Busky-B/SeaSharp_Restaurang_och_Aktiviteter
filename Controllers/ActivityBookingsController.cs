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
    public class ActivityBookingsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public ActivityBookingsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/ActivityBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityBooking>>> GetActivityBooking()
        {
            return await _context.ActivityBooking.ToListAsync();
        }

        // GET: api/ActivityBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityBooking>> GetActivityBooking(int id)
        {
            var activityBooking = await _context.ActivityBooking.FindAsync(id);

            if (activityBooking == null)
            {
                return NotFound();
            }

            return activityBooking;
        }

        // PUT: api/ActivityBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityBooking(int id, ActivityBooking activityBooking)
        {
            if (id != activityBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityBookingExists(id))
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

        // POST: api/ActivityBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityBooking>> PostActivityBooking(ActivityBooking activityBooking)
        {
            _context.ActivityBooking.Add(activityBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityBooking", new { id = activityBooking.Id }, activityBooking);
        }

        // DELETE: api/ActivityBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityBooking(int id)
        {
            var activityBooking = await _context.ActivityBooking.FindAsync(id);
            if (activityBooking == null)
            {
                return NotFound();
            }

            _context.ActivityBooking.Remove(activityBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityBookingExists(int id)
        {
            return _context.ActivityBooking.Any(e => e.Id == id);
        }
    }
}
