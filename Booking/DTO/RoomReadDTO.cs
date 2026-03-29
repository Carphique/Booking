namespace Booking.DTO
{
    public class RoomReadDTO
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
