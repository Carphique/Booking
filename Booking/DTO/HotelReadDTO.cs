namespace Booking.DTO
{
    public class HotelReadDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public double Rating { get; set; }
        public int AvailableRoomsCount { get; set; }
        public string? ImagePath { get; set; }
    }
}
