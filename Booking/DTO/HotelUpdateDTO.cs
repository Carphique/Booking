using System.ComponentModel.DataAnnotations;

namespace Booking.DTO
{
    public class HotelUpdateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public double Rating { get; set; }
        public int AvailableRoomsCount { get; set; }
    }
}
