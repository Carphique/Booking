using Booking.Data;
using Booking.DTO;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Create(BookingCreateDTO dto)
        {
            var room = await _context.Rooms.FindAsync(dto.RoomId);
            if (room == null || !room.IsAvailable)
                return BadRequest("Room not available");

            var booking = new Booking.Models.Booking
            {
                Id = Guid.NewGuid(),
                HotelId = dto.HotelId,
                RoomId = dto.RoomId,
                UserId = dto.UserId,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                IsCancelled = false
            };

            room.IsAvailable = false;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        [HttpPut("{id:guid}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            booking.IsCancelled = true;
            var room = await _context.Rooms.FindAsync(booking.RoomId);
            if (room != null) room.IsAvailable = true;

            await _context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<List<BookingReadDTO>>> GetUserBookings(Guid userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Select(b => new BookingReadDTO
                {
                    Id = b.Id,
                    HotelId = b.HotelId,
                    RoomId = b.RoomId,
                    UserId = b.UserId,
                    DateFrom = b.DateFrom,
                    DateTo = b.DateTo,
                    IsCancelled = b.IsCancelled
                }).ToListAsync();
        }
    }
}
