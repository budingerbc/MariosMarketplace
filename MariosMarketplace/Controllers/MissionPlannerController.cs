using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MariosMarketplace.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MariosMarketplace.Controllers
{
    public class MissionPlannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
