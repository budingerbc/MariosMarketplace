using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MariosMarketplace.Models
{
    public class EFReviewsRepository : IReviewRepository
    {
        MariosMarketplaceContext db = null;

        public EFReviewsRepository(MariosMarketplaceContext connection = null)
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

        public IQueryable<Review> Reviews
        { get { return db.Reviews; }}

        public void RemoveAll()
        {
            db.Reviews.RemoveRange(db.Reviews);
            db.SaveChanges();
        }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Delete(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
            return review;
        }
    }
}
