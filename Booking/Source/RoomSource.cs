using Booking.Data;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Sources
{
    public class RoomSource
    {
        private readonly AppDbContext _context;
        public RoomSource(AppDbContext context) => _context = context;

        public async Task<List<Room>> GetByHotelIdAsync(Guid hotelId) =>
            await _context.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();

        public async Task CreateAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null) return false;
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}