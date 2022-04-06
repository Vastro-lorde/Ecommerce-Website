using SpiritEcommerce.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpiritEcommerce.Models
{
    public class Product
    {
        public string Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
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
                    TotalRating += (int)review[i].Rate;
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
