namespace SpiritEcommerce.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Details { get; set; }
        public int Rate { get; set; }
    }
}
