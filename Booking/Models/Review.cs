namespace Booking.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
