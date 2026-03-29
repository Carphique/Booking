namespace Booking.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int RoomsAvailable { get; set; }
    }
}
