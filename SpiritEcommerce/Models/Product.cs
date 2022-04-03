using SpiritEcommerce.Enum;
using System.Collections.Generic;

namespace SpiritEcommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PercentOff { get; set; }
        public decimal DiscountUnitPrice
        {
            get { return UnitPrice * PercentOff; }
        }
        public int Rating
        {
            get
            {
                int TotalRating = 0;
                var review = Reviews;
                for (int i = 0; i < review.Count; i++)
                {
                    TotalRating += review[i].Rate;
                }
                int rating = TotalRating / review.Count;
                return rating;
            }
        }
        public int Quantity { get; set; }
        public string Availability
        {
            get
            {
                if (Quantity == 0) return "Out of Stock";
                return "In Stock";
            }
        }
        public string UserId { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
