using Booking.Data;
using Booking.Models;
using Booking.Sources;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Booking.Tests
{
    public class HotelSourceTests
    {
        // Метод для создания фейковой базы данных в оперативной памяти
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddHotelToDatabase()
        {
            // 1. Arrange (Підготовка)
            var dbContext = GetDbContext();
            var source = new HotelSource(dbContext);
            var hotel = new Hotel
            {
                Id = Guid.NewGuid(),
                Name = "Grand Resort Spa",
                City = "Одеса",
                PricePerNight = 1200
            };

            // 2. Act (Дія)
            await source.CreateAsync(hotel);

            // 3. Assert (Перевірка результату)
            var savedHotel = await dbContext.Hotels.FirstOrDefaultAsync(h => h.Name == "Grand Resort Spa");

            Assert.NotNull(savedHotel);
            Assert.Equal("Одеса", savedHotel.City);
            Assert.Equal(1200, savedHotel.PricePerNight);
        }
    }
}