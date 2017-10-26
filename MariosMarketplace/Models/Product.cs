using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MariosMarketplace.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price of product required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Country of Origin required")]
        public string CountryOrigin { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

		public Product()
		{
			this.Reviews = new HashSet<Review>();
		}

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }

        public double CalculateAverageRating()
        {
            int RatingSum = 0;

            foreach(var review in this.Reviews)
            {
                RatingSum += review.Rating;
            }

            return ((double)RatingSum / this.Reviews.Count());
        }
    }
}