using Booking.Data;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Sources
{
    public class FavoriteSource
    {
        private readonly AppDbContext _context;
        public FavoriteSource(AppDbContext context) => _context = context;

        public async Task<List<Hotel>> GetUserFavoritesAsync(Guid userId) =>
            await _context.FavoriteHotels
                .Where(f => f.UserId == userId)
                .Select(f => f.Hotel!)
                .ToListAsync();

        public async Task AddAsync(FavoriteHotel favorite)
        {
            _context.FavoriteHotels.Add(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var favorite = await _context.FavoriteHotels.FindAsync(id);
            if (favorite == null) return false;
            _context.FavoriteHotels.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}