using Booking.DTO;
using Booking.Models;
using Booking.Sources;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoriteSource _source;
        public FavoritesController(FavoriteSource source) => _source = source;

        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetUserFavorites(Guid userId)
        {
            var favorites = await _source.GetUserFavoritesAsync(userId);
            return Ok(favorites);
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

            await _source.AddAsync(favorite);
            return Ok(favorite);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveFavorite(Guid id)
        {
            return await _source.RemoveAsync(id) ? NoContent() : NotFound();
        }
    }
}