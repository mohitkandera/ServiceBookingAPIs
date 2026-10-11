using ServiceBookingAPI.Models;

namespace ServiceBookingAPI.Models
{
    public class Bookings
    {
        public int Id { get; set; }

        // customer
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string? Address { get; set; }

        // Navigation properties
        public Users? User { get; set; }
        public Services? Service { get; set; }
    
    }
}
