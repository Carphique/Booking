namespace Booking.Models
{
    public class Booking
    {
        internal string UserEmail;

        public Guid Id { get; set; }

        public Guid HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public Guid RoomId { get; set; }
        public Room? Room { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsCancelled { get; set; } = false;
    }
}