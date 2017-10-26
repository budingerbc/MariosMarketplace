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
            return View();
        }

        public IActionResult Create(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(products => products.ProductId == id);
            ViewBag.product = thisProduct;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                reviewRepo.Save(review);
                return RedirectToAction("Details", "Products", new { id = review.ProductId });
            }
            else
            {
                return View("Error", review);
            }

        }
    }
}
