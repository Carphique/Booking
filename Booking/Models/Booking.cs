namespace Booking.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
