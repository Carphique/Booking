using Booking.Data;
using Booking.DTO;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public ReviewsController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet("hotel/{hotelId:guid}")]
        public async Task<ActionResult<List<ReviewReadDTO>>> GetHotelReviews(Guid hotelId)
        {
            return await _context.Reviews
                .Where(r => r.HotelId == hotelId)
                .Select(r => new ReviewReadDTO
                {
                    Id = r.Id,
                    HotelId = r.HotelId,
                    UserId = r.UserId,
                    Rating = r.Rating,
                    Comment = r.Comment
                }).ToListAsync();
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

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return Ok(review);
        }
    }
}
