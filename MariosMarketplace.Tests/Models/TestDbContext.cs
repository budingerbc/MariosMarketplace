using System;
using Microsoft.EntityFrameworkCore;

namespace MariosMarketplace.Models
{
    public class TestDbContext : MariosMarketplaceContext
    {
        public override DbSet<Product> Products { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=marketplace_test;uid=root;pwd=root;");
        }
    }
}
