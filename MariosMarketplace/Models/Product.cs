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
        public Product()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CountryOrigin { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}