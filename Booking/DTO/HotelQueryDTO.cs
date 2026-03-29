using System.ComponentModel.DataAnnotations;

namespace Booking.DTO
{
    public class HotelQueryDTO
    {
        public string? City { get; set; }
        [Range(0, 999999)]
        public decimal MinPrice { get; set; }
        [Range(0, 999999)]
        public decimal MaxPrice { get; set; }
        [Range(0, 5)]
        public double MinRating { get; set; }
    }
}
