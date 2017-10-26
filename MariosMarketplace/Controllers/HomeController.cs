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
            var allProducts = db.Products.ToList().OrderByDescending(product => product.ProductId);


            return View(allProducts);
        }
    }
}
