using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MariosMarketplace.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Review author required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Review body required")]
        [StringLength(250, MinimumLength  = 50)]
        public string Content { get; set; }
        [Required(ErrorMessage = "Rating from 1 to 5 required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Review()
        {
            
        }

        public Review(string author, string content, int rating, int productId, int id = 0)
        {
            Author = author;
            Content = content;
            Rating = rating;
            ProductId = productId;
            ReviewId = id;
        }

        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                return this.ReviewId.Equals(newReview.ReviewId);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }
    }
}
