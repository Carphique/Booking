using Booking.Data;
using Microsoft.EntityFrameworkCore;

namespace Booking.Sources
{
    public class BookingSource
    {
        private readonly AppDbContext _context;
        public BookingSource(AppDbContext context) => _context = context;

        public async Task<Booking.Models.Booking?> CreateAsync(Booking.Models.Booking booking)
        {
            var room = await _context.Rooms.FindAsync(booking.RoomId);
            if (room == null || !room.IsAvailable) return null;

            room.IsAvailable = false;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> CancelAsync(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return false;

            booking.IsCancelled = true;
            var room = await _context.Rooms.FindAsync(booking.RoomId);
            if (room != null) room.IsAvailable = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Booking.Models.Booking>> GetByUserIdAsync(Guid userId) =>
            await _context.Bookings.Include(b => b.Hotel).Where(b => b.UserId == userId).ToListAsync();
    }
}