namespace Booking.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<Booking> Bookings { get; set; } = new();
        public List<FavoriteHotel> Favorites { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}