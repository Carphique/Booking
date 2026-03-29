using System.ComponentModel.DataAnnotations;

namespace Booking.DTO
{
    public class BookingCreateDTO
    {
        [Required]
        public Guid HotelId { get; set; }
        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
    }
}
