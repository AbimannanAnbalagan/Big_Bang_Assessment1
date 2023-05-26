using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingsController : ControllerBase
    {
        private readonly FinalDbContext _context;

        public HotelBookingsController(FinalDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelBooking>>> GethotelBookings()
        {
          if (_context.hotelBookings == null)
          {
              return NotFound();
          }
            return await _context.hotelBookings.ToListAsync();
        }

        // GET: api/HotelBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelBooking>> GetHotelBooking(int id)
        {
          if (_context.hotelBookings == null)
          {
              return NotFound();
          }
            var hotelBooking = await _context.hotelBookings.FindAsync(id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return hotelBooking;
        }

        // PUT: api/HotelBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelBooking(int id, HotelBooking hotelBooking)
        {
            if (id != hotelBooking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(hotelBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelBookingExists(id))
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

        // POST: api/HotelBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelBooking>> PostHotelBooking(HotelBooking hotelBooking)
        {
          if (_context.hotelBookings == null)
          {
              return Problem("Entity set 'FinalDbContext.hotelBookings'  is null.");
          }
            _context.hotelBookings.Add(hotelBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelBooking", new { id = hotelBooking.BookingId }, hotelBooking);
        }

        // DELETE: api/HotelBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelBooking(int id)
        {
            if (_context.hotelBookings == null)
            {
                return NotFound();
            }
            var hotelBooking = await _context.hotelBookings.FindAsync(id);
            if (hotelBooking == null)
            {
                return NotFound();
            }

            _context.hotelBookings.Remove(hotelBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelBookingExists(int id)
        {
            return (_context.hotelBookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
