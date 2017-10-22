using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MariosMarketplace.Models
{
    public class MariosMarketplaceContext : DbContext
    {
        public MariosMarketplaceContext()
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=marketplace;uid=root;pwd=root;");

        public MariosMarketplaceContext(DbContextOptions<MariosMarketplaceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}