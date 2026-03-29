using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Data;
using Booking.Models;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public HotelsController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetAll()
        {
            return await _context.Hotels.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddHotel(Hotel hotel)
        {
            hotel.Id = Guid.NewGuid();
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return Ok(hotel);
        }
    }
}
