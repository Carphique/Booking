using System.ComponentModel.DataAnnotations;

namespace Booking.DTO
{
    public class HotelCreateDTO
    {
        [Required, MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Range(0, 999999)]
        public decimal PricePerNight { get; set; }
        public IFormFile? Image { get; set; }
    }
}
