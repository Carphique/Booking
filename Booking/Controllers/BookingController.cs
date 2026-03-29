using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Data;
using Booking.Models;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public BookingsController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking.Models.Booking booking)
        {
            var hotel = await _context.Hotels.FindAsync(booking.HotelId);
            if (hotel == null || hotel.RoomsAvailable <= 0)
                return BadRequest("No rooms available");

            booking.Id = Guid.NewGuid();
            _context.Bookings.Add(booking);

            hotel.RoomsAvailable--;
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<List<Booking.Models.Booking>>> GetUserBookings(string email)
        {
            return await _context.Bookings
                .Where(b => b.UserEmail == email)
                .ToListAsync();
        }
    }
}
