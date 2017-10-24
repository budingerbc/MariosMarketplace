using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MariosMarketplace.Models;
using MariosMarketplace.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MariosMarketplace.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void GetDescriptionTest()
        {
            ProductsController controller = new ProductsController();

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void GetModelListIndexText()
        {
            ViewResult indexView = new ProductsController().Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }
    }
}
