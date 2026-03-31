namespace Booking.Models
{
    public class Booking
    {
        public string? UserEmail { get; set; }
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsCancelled { get; set; } = false;
        
    }
}
