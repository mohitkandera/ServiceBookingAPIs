using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceBookingAPI.Data;
using ServiceBookingAPI.Models;

namespace ServiceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

     [HttpGet]
       public async Task<IActionResult> GetBooking()
        {
            var Booking = _context.Categories.ToListAsync();
            return Ok(Booking);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = _context.Bookings.ToListAsync();

            if(booking != null)
            {
                return Ok(booking);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Bookings booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBooking(int id )
        {
            var booking = await _context.Bookings.FindAsync();

            if(booking == null)
            {
                return BadRequest();
            }
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBoking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if(booking == null)
            {
                return NotFound("Booking Not Found");
            }
            _context.Bookings.Remove(booking);

            await _context.SaveChangesAsync();

            return Ok("Booking Deleted Successfully . ");
        }



    }
}
