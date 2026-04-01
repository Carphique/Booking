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

            // 1. User <-> Booking (1:N)
            modelBuilder.Entity<Booking.Models.Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 2. Hotel <-> Room (1:N)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3. User <-> Review (1:N)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict запобігає конфліктам видалення

            // 4. Hotel <-> Review (1:N)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Reviews)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // 5. User <-> FavoriteHotel (1:N)
            modelBuilder.Entity<FavoriteHotel>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 6. Hotel <-> FavoriteHotel (1:N)
            modelBuilder.Entity<FavoriteHotel>()
                .HasOne(f => f.Hotel)
                .WithMany(h => h.FavoritedByUsers)
                .HasForeignKey(f => f.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            // 7. Hotel <-> Booking (1:N)
            modelBuilder.Entity<Booking.Models.Booking>()
                .HasOne(b => b.Hotel)
                .WithMany(h => h.Bookings)
                .HasForeignKey(b => b.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            // 8. Room <-> Booking (1:N)
            modelBuilder.Entity<Booking.Models.Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hotel>()
                .Property(h => h.PricePerNight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Room>()
                .Property(r => r.PricePerNight)
                .HasPrecision(18, 2);
        }
    }
}