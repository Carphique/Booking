namespace Booking.Models
{
    public class FavoriteHotel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }
    }
}
