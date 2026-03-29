namespace Booking.DTO
{
    public class RoomUpdateDTO
    {
        public string RoomType { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
