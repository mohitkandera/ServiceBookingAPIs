using ServiceBookingAPI.Models; 

namespace ServiceBookingAPI.Models
{
    public class Services
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ProviderId { get; set; }

        //Navigation properties
        public Categories? Category {get; set;}
        public Users? Provider { get; set; }
        public ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();

    }
}
