namespace Booking.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = "Standard";
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
