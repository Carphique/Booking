using Booking.DTO;
using Booking.Models;
using Booking.Sources;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomSource _source;
        public RoomsController(RoomSource source) => _source = source;

        [HttpGet("hotel/{hotelId:guid}")]
        public async Task<IActionResult> GetRooms(Guid hotelId)
        {
            var rooms = await _source.GetByHotelIdAsync(hotelId);
            return Ok(rooms);
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

            await _source.CreateAsync(room);
            return Ok(room);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await _source.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}