using SpiritEcommerce.Enums;

namespace SpiritEcommerce.Models
{
    public class Review
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Details { get; set; }
        public Ratings Rate { get; set; }
    }
}
