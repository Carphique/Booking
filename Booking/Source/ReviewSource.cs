using Booking.Data;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Sources
{
    public class ReviewSource
    {
        private readonly AppDbContext _context;
        private readonly HotelSource _hotelSource;

        public ReviewSource(AppDbContext context, HotelSource hotelSource)
        {
            _context = context;
            _hotelSource = hotelSource;
        }

        public async Task CreateAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            await _hotelSource.RefreshRatingAsync(review.HotelId);
        }

        public async Task<List<Review>> GetByHotelIdAsync(Guid hotelId) =>
            await _context.Reviews.Include(r => r.User).Where(r => r.HotelId == hotelId).ToListAsync();
    }
}