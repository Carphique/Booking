using System.ComponentModel.DataAnnotations;

namespace Booking.DTO
{
    public class HotelUpdateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Range(0, 999999)]
        public decimal PricePerNight { get; set; }
        public double Rating { get; set; }
        public int AvailableRoomsCount { get; set; }
        public string? ImagePath { get; set; }
    }
}