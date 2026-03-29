namespace Booking.DTO
{
    public class ReviewReadDTO
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
