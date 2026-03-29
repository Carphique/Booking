using Booking.Data;
using Booking.DTO;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<HotelReadDTO>>> GetAll([FromQuery] HotelQueryDTO query)
        {
            var hotels = _context.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(query.City))
                hotels = hotels.Where(h => h.City == query.City);

            if (query.MinPrice > 0)
                hotels = hotels.Where(h => h.PricePerNight >= query.MinPrice);

            if (query.MaxPrice > 0)
                hotels = hotels.Where(h => h.PricePerNight <= query.MaxPrice);

            if (query.MinRating > 0)
                hotels = hotels.Where(h => h.Rating >= query.MinRating);

            return await hotels.Select(h => new HotelReadDTO
            {
                Id = h.Id,
                Name = h.Name,
                City = h.City,
                PricePerNight = h.PricePerNight,
                Rating = h.Rating,
                AvailableRoomsCount = h.AvailableRoomsCount,
                ImagePath = h.ImagePath
            }).ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HotelReadDTO>> GetById(Guid id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) return NotFound();

            return new HotelReadDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City,
                PricePerNight = hotel.PricePerNight,
                Rating = hotel.Rating,
                AvailableRoomsCount = hotel.AvailableRoomsCount,
                ImagePath = hotel.ImagePath
            };
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] HotelCreateDTO dto)
        {
            var hotel = new Hotel
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                City = dto.City,
                PricePerNight = dto.PricePerNight,
                Rating = 0,
                AvailableRoomsCount = 0,
                ImagePath = dto.Image?.FileName
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, HotelUpdateDTO dto)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) return NotFound();

            hotel.Name = dto.Name;
            hotel.City = dto.City;
            hotel.PricePerNight = dto.PricePerNight;
            hotel.Rating = dto.Rating;
            hotel.AvailableRoomsCount = dto.AvailableRoomsCount;

            await _context.SaveChangesAsync();
            return Ok(hotel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) return NotFound();

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
