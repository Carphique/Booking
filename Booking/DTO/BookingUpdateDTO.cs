namespace Booking.DTO
{
    public class BookingUpdateDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsCancelled { get; set; }
    }
}
    