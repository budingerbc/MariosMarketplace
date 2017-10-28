using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MariosMarketplace.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MariosMarketplace.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;
        private IProductRepository productRepo = new EFProductRepository();

        public ReviewsController(IReviewRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.reviewRepo = new EFReviewsRepository();
            }
            else
            {
                this.reviewRepo = thisRepo;    
            }
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(reviewRepo.Reviews.ToList());
        }

        public IActionResult Create(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(products => products.ProductId == id);
            ViewBag.product = thisProduct;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int ProductId, string author, string content, int rating)
        {
            if (author == null || content == null)
            {
                return RedirectToAction("Error");
            }
            bool verify_author = author.Length != 0;
            bool verify_content = (content.Length >= 50 && content.Length <= 250);
            bool verify_rating = (rating >= 1 && rating <= 5);

            if (verify_author && verify_content && verify_rating)
            {
                Review newReview = new Review(author, content, rating, ProductId);
                reviewRepo.Save(newReview);
                return RedirectToAction("Details", "Products", new { id = newReview.ProductId });
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Delete(int productId, int reviewId)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == reviewId);
            ViewBag.productId = productId;

            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int productId, int reviewId)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == reviewId);
            reviewRepo.Delete(thisReview);
            return RedirectToAction("Details", "Products", new { id = productId });
        }
    }
}
