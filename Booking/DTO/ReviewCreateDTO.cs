using System.ComponentModel.DataAnnotations;

namespace Booking.DTO
{
    public class ReviewCreateDTO
    {
        [Required]
        public Guid HotelId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
