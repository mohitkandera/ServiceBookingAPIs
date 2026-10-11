using ServiceBookingAPI.Models;

namespace ServiceBookingAPI.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation property for related services
        public ICollection<Services> Services { get; set; } = new List<Services>();
    }
}
