using System.ComponentModel.DataAnnotations;

namespace Booking.DTO
{
    public class RoomCreateDTO
    {
        [Required]
        public Guid HotelId { get; set; }
        [Required]
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = "Standard";
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
