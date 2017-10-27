using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MariosMarketplace.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MariosMarketplace.Controllers
{
    public class HomeController : Controller
    {

        private EFProductRepository db = new EFProductRepository();

        public IActionResult Index()
        {
            List<Product> recentlyAdded = db.Products.OrderByDescending(product => product.ProductId).Take(3).ToList();
            List<Product> highlyRated = db.Products.Include(product => product.Reviews).OrderByDescending(review => review.CalculateAverageRating()).Take(3).ToList();

            Dictionary<string, List<Product>> dict = new Dictionary<string, List<Product>>();
            dict.Add("recent", recentlyAdded);
            dict.Add("highlyRated", highlyRated);

            return View(dict);
        }
    }
}
