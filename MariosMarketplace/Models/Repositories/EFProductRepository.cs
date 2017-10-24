using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariosMarketplace.Models
{
    public class EFProductRepository : IProductRepository
    {
        MariosMarketplaceContext db = null;

        public EFProductRepository(MariosMarketplaceContext connection = null)
        {
            if (connection == null)
            {
                this.db = new MariosMarketplaceContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Product Edit(Product product)
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }
    }
}
