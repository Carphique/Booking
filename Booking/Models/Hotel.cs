namespace Booking.Models
{
    public class Hotel
    {
        internal int RoomsAvailable;

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public double Rating { get; set; }
        public int AvailableRoomsCount { get; set; }
        public string? ImagePath { get; set; }

        public List<Room> Rooms { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();
        public List<FavoriteHotel> FavoritedByUsers { get; set; } = new();
    }
}