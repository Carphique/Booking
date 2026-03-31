using Booking.Data;
using Booking.DTO;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public RoomsController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet("hotel/{hotelId:guid}")]
        public async Task<ActionResult<List<RoomReadDTO>>> GetRooms(Guid hotelId)
        {
            return await _context.Rooms
                .Where(r => r.HotelId == hotelId)
                .Select(r => new RoomReadDTO
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomType = r.RoomType,
                    Capacity = r.Capacity,
                    PricePerNight = r.PricePerNight,
                    IsAvailable = r.IsAvailable
                }).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateDTO dto)
        {
            var room = new Room
            {
                Id = Guid.NewGuid(),
                HotelId = dto.HotelId,
                RoomNumber = dto.RoomNumber,
                RoomType = dto.RoomType,
                Capacity = dto.Capacity,
                PricePerNight = dto.PricePerNight,
                IsAvailable = true
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return Ok(room);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, RoomUpdateDTO dto)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null) return NotFound();

            room.RoomType = dto.RoomType;
            room.Capacity = dto.Capacity;
            room.PricePerNight = dto.PricePerNight;
            room.IsAvailable = dto.IsAvailable;

            await _context.SaveChangesAsync();
            return Ok(room);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null) return NotFound();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
