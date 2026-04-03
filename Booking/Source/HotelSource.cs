using Booking.Data;
using Booking.DTO;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Sources
{
    public class HotelSource
    {
        private readonly AppDbContext _context;
        public HotelSource(AppDbContext context) => _context = context;

        public async Task<List<Hotel>> GetAllAsync(HotelQueryDTO query)
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

            return await hotels.ToListAsync();
        }

        public async Task<Hotel?> GetByIdAsync(Guid id) =>
            await _context.Hotels.Include(h => h.Rooms).Include(h => h.Reviews).FirstOrDefaultAsync(h => h.Id == id);

        public async Task CreateAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Guid id, HotelUpdateDTO dto)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) return false;

            hotel.Name = dto.Name;
            hotel.City = dto.City;
            hotel.PricePerNight = dto.PricePerNight;
            hotel.AvailableRoomsCount = dto.AvailableRoomsCount;
            if (!string.IsNullOrEmpty(dto.ImagePath)) hotel.ImagePath = dto.ImagePath;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task RefreshRatingAsync(Guid hotelId)
        {
            var hotel = await _context.Hotels.Include(h => h.Reviews).FirstOrDefaultAsync(h => h.Id == hotelId);
            if (hotel != null && hotel.Reviews.Any())
            {
                hotel.Rating = Math.Round(hotel.Reviews.Average(r => r.Rating), 1);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) return false;
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}