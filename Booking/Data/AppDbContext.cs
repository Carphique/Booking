using Microsoft.EntityFrameworkCore;
using Booking.Models;

namespace Booking.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Booking.Models.Booking> Bookings => Set<Booking.Models.Booking>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<FavoriteHotel> FavoriteHotels => Set<FavoriteHotel>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking.Models.Booking>().HasOne(b => b.User).WithMany(u => u.Bookings).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Room>().HasOne(r => r.Hotel).WithMany(h => h.Rooms).HasForeignKey(r => r.HotelId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>().HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>().HasOne(r => r.Hotel).WithMany(h => h.Reviews).HasForeignKey(r => r.HotelId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FavoriteHotel>().HasOne(f => f.User).WithMany(u => u.Favorites).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FavoriteHotel>().HasOne(f => f.Hotel).WithMany(h => h.FavoritedByUsers).HasForeignKey(f => f.HotelId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking.Models.Booking>().HasOne(b => b.Hotel).WithMany(h => h.Bookings).HasForeignKey(b => b.HotelId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking.Models.Booking>().HasOne(b => b.Room).WithMany(r => r.Bookings).HasForeignKey(b => b.RoomId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hotel>().Property(h => h.PricePerNight).HasPrecision(18, 2);
            modelBuilder.Entity<Room>().Property(r => r.PricePerNight).HasPrecision(18, 2);

            // ЛОКАЛЬНІ КАРТИНКИ (100% залізобетон, ніхто не заблокує)
            string img1 = "/images/1.jpg";
            string img2 = "/images/2.jpg";
            string img3 = "/images/3.jpg";
            string img4 = "/images/4.jpg";
            string img5 = "/images/5.jpg";
            string img6 = "/images/6.jpg";

            // === 50 ГОТЕЛІВ ===
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Premier Palace Hotel", City = "Київ", PricePerNight = 5000, Rating = 9.2, AvailableRoomsCount = 4, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Hilton Kyiv", City = "Київ", PricePerNight = 7500, Rating = 9.4, AvailableRoomsCount = 2, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "M1 Club Hotel", City = "Одеса", PricePerNight = 4500, Rating = 9.5, AvailableRoomsCount = 3, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Bristol Hotel", City = "Одеса", PricePerNight = 3200, Rating = 9.0, AvailableRoomsCount = 5, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Bankhotel", City = "Львів", PricePerNight = 4100, Rating = 9.6, AvailableRoomsCount = 6, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Grand Hotel Lviv", City = "Львів", PricePerNight = 3800, Rating = 9.2, AvailableRoomsCount = 3, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Kharkiv Palace", City = "Харків", PricePerNight = 3500, Rating = 9.4, AvailableRoomsCount = 7, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Nemo Hotel Kharkiv", City = "Харків", PricePerNight = 4200, Rating = 9.1, AvailableRoomsCount = 4, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Menorah Hotel", City = "Дніпро", PricePerNight = 2900, Rating = 9.3, AvailableRoomsCount = 10, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Bartolomeo Resort", City = "Дніпро", PricePerNight = 4800, Rating = 9.0, AvailableRoomsCount = 2, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Hotel France", City = "Вінниця", PricePerNight = 2500, Rating = 9.1, AvailableRoomsCount = 5, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Feride Hotel", City = "Вінниця", PricePerNight = 2800, Rating = 8.9, AvailableRoomsCount = 3, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Noble Boutique Hotel", City = "Луцьк", PricePerNight = 2300, Rating = 9.4, AvailableRoomsCount = 2, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Zalesie Hotel", City = "Луцьк", PricePerNight = 1800, Rating = 8.7, AvailableRoomsCount = 6, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Donbass Palace", City = "Донецьк", PricePerNight = 4000, Rating = 9.2, AvailableRoomsCount = 5, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Victoria Hotel", City = "Донецьк", PricePerNight = 3500, Rating = 8.8, AvailableRoomsCount = 8, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Reikartz Zhytomyr", City = "Житомир", PricePerNight = 2100, Rating = 8.6, AvailableRoomsCount = 12, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Name = "Chalet Hotel", City = "Житомир", PricePerNight = 2400, Rating = 9.0, AvailableRoomsCount = 4, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000019"), Name = "Hotel Duet Plus", City = "Ужгород", PricePerNight = 2600, Rating = 9.3, AvailableRoomsCount = 5, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000020"), Name = "Praha Hotel", City = "Ужгород", PricePerNight = 2200, Rating = 8.9, AvailableRoomsCount = 7, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000021"), Name = "Khortitsa Palace", City = "Запоріжжя", PricePerNight = 3100, Rating = 9.1, AvailableRoomsCount = 8, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000022"), Name = "Intourist Hotel", City = "Запоріжжя", PricePerNight = 1900, Rating = 8.5, AvailableRoomsCount = 15, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000023"), Name = "Nadiya Hotel", City = "Івано-Франківськ", PricePerNight = 2400, Rating = 9.2, AvailableRoomsCount = 6, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000024"), Name = "Stanislaviv", City = "Івано-Франківськ", PricePerNight = 2000, Rating = 8.8, AvailableRoomsCount = 4, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000025"), Name = "Reikartz Kropyvnytskyi", City = "Кропивницький", PricePerNight = 2200, Rating = 8.7, AvailableRoomsCount = 9, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000026"), Name = "Hotel Zirka", City = "Кропивницький", PricePerNight = 1600, Rating = 8.2, AvailableRoomsCount = 11, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000027"), Name = "Hotel Initial", City = "Луганськ", PricePerNight = 1800, Rating = 8.4, AvailableRoomsCount = 5, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000028"), Name = "Druzhba Hotel", City = "Луганськ", PricePerNight = 1500, Rating = 8.0, AvailableRoomsCount = 8, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000029"), Name = "Reikartz River", City = "Миколаїв", PricePerNight = 2500, Rating = 9.0, AvailableRoomsCount = 7, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000030"), Name = "Palace Ukraine", City = "Миколаїв", PricePerNight = 2100, Rating = 8.6, AvailableRoomsCount = 4, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000031"), Name = "Premier Hotel Palazzo", City = "Полтава", PricePerNight = 2700, Rating = 9.4, AvailableRoomsCount = 3, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000032"), Name = "Reikartz Gallery", City = "Полтава", PricePerNight = 2300, Rating = 8.9, AvailableRoomsCount = 6, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000033"), Name = "Boutique Hotel", City = "Рівне", PricePerNight = 2600, Rating = 9.2, AvailableRoomsCount = 2, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000034"), Name = "Optima Rivne", City = "Рівне", PricePerNight = 1900, Rating = 8.5, AvailableRoomsCount = 8, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000035"), Name = "Reikartz Sumy", City = "Суми", PricePerNight = 2000, Rating = 8.8, AvailableRoomsCount = 5, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000036"), Name = "Shafran Hotel", City = "Суми", PricePerNight = 2200, Rating = 9.1, AvailableRoomsCount = 3, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000037"), Name = "Avalon Palace", City = "Тернопіль", PricePerNight = 2400, Rating = 9.0, AvailableRoomsCount = 6, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000038"), Name = "Garden Hall", City = "Тернопіль", PricePerNight = 2100, Rating = 8.6, AvailableRoomsCount = 4, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000039"), Name = "Optima Kherson", City = "Херсон", PricePerNight = 1800, Rating = 8.5, AvailableRoomsCount = 10, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000040"), Name = "Play Hotel by Ribas", City = "Херсон", PricePerNight = 2300, Rating = 9.2, AvailableRoomsCount = 3, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000041"), Name = "Arena Hotel", City = "Хмельницький", PricePerNight = 2500, Rating = 9.1, AvailableRoomsCount = 4, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000042"), Name = "Sobkoff Hotel", City = "Хмельницький", PricePerNight = 2800, Rating = 9.4, AvailableRoomsCount = 2, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000043"), Name = "Apelsin Hotel", City = "Черкаси", PricePerNight = 2200, Rating = 8.9, AvailableRoomsCount = 6, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000044"), Name = "Optima Cherkasy", City = "Черкаси", PricePerNight = 1900, Rating = 8.6, AvailableRoomsCount = 8, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000045"), Name = "Bukovyna Hotel", City = "Чернівці", PricePerNight = 2700, Rating = 9.3, AvailableRoomsCount = 5, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000046"), Name = "AllureInn", City = "Чернівці", PricePerNight = 3000, Rating = 9.5, AvailableRoomsCount = 2, ImagePath = img4 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000047"), Name = "Riverside Resort", City = "Чернігів", PricePerNight = 2400, Rating = 9.0, AvailableRoomsCount = 7, ImagePath = img5 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000048"), Name = "Reikartz Chernihiv", City = "Чернігів", PricePerNight = 2100, Rating = 8.7, AvailableRoomsCount = 5, ImagePath = img6 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000049"), Name = "Ukraina Hotel", City = "Сімферополь", PricePerNight = 3500, Rating = 8.8, AvailableRoomsCount = 4, ImagePath = img1 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000050"), Name = "Yalta Intourist", City = "Ялта", PricePerNight = 5500, Rating = 9.4, AvailableRoomsCount = 2, ImagePath = img2 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000051"), Name = "Radisson Blu Resort", City = "Буковель", PricePerNight = 6200, Rating = 9.3, AvailableRoomsCount = 8, ImagePath = img3 },
                new Hotel { Id = Guid.Parse("00000000-0000-0000-0000-000000000052"), Name = "F&B Spa Resort", City = "Буковель", PricePerNight = 5100, Rating = 9.0, AvailableRoomsCount = 5, ImagePath = img4 }
            );
        }
    }
}