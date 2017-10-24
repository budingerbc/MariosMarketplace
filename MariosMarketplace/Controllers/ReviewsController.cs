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
        private MariosMarketplaceContext db = new MariosMarketplaceContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(products => products.ProductId == id);
            ViewBag.product = thisProduct;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Details", "Products", new { id = review.ProductId });
            }
            else
            {
                return View("Error", review);
            }

        }
    }
}
