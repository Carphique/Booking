using Booking.Data;
using Booking.DTO;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/favorites")]
    public class FavoritesController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public FavoritesController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<List<HotelReadDTO>>> GetUserFavorites(Guid userId)
        {
            var favorites = await _context.FavoriteHotels
                .Where(f => f.UserId == userId)
                .Select(f => f.HotelId)
                .ToListAsync();

            return await _context.Hotels
                .Where(h => favorites.Contains(h.Id))
                .Select(h => new HotelReadDTO
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

        [HttpPost]
        public async Task<IActionResult> AddFavorite(FavoriteHotelDTO dto)
        {
            var favorite = new FavoriteHotel
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                HotelId = dto.HotelId
            };

            _context.FavoriteHotels.Add(favorite);
            await _context.SaveChangesAsync();
            return Ok(favorite);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveFavorite(Guid id)
        {
            var favorite = await _context.FavoriteHotels.FindAsync(id);
            if (favorite == null) return NotFound();

            _context.FavoriteHotels.Remove(favorite);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
