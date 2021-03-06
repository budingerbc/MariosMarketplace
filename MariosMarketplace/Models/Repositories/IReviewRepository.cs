﻿using System;
using System.Linq;

namespace MariosMarketplace.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        Review Save(Review review);
        Review Delete(Review review);
        void RemoveAll();
    }
}
