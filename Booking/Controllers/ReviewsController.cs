using Booking.DTO;
using Booking.Models;
using Booking.Sources;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewSource _source;
        public ReviewsController(ReviewSource source) => _source = source;

        [HttpGet("hotel/{hotelId:guid}")]
        public async Task<IActionResult> GetHotelReviews(Guid hotelId)
        {
            var reviews = await _source.GetByHotelIdAsync(hotelId);
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewCreateDTO dto)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                HotelId = dto.HotelId,
                UserId = dto.UserId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            await _source.CreateAsync(review);
            return Ok(review);
        }
    }
}