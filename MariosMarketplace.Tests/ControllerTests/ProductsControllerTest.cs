using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MariosMarketplace.Models;
using MariosMarketplace.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace MariosMarketplace.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();

        private void DbSetup()
        {
			mock.Setup(mock => mock.Products).Returns(new Product[] {
					new Product {ProductId = 1, Name = "Cherries" },
					new Product {ProductId = 2, Name = "Blueberries" },
					new Product {ProductId = 3, Name = "Strawberries" }
				}.AsQueryable());
        }

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

        [TestMethod]
        public void Mock_GetViewResultsIndex_Test()
        {
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexListOfItems_Test()
        {
            DbSetup();
            ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }

        [TestMethod]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);
            Product testProduct = new Product();
            testProduct.Name = "Cherries";
            testProduct.ProductId = 1;

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.Model as List<Product>;

            CollectionAssert.Contains(collection, testProduct);
        }
    }
}