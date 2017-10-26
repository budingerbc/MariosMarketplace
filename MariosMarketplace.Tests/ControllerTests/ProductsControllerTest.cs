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
    public class ProductsControllerTest : IDisposable
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();
        EFProductRepository db = new EFProductRepository(new TestDbContext());

        private void DbSetup()
        {
			mock.Setup(mock => mock.Products).Returns(new Product[] {
					new Product {ProductId = 1, Name = "Cherries" },
					new Product {ProductId = 2, Name = "Blueberries" },
					new Product {ProductId = 3, Name = "Strawberries" }
				}.AsQueryable());
        }

        public void Dispose()
        {
            db.RemoveAll();
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

        [TestMethod]
        public void DB_CreateNewEntry_Test()
        {
            ProductsController controller = new ProductsController(db);
            Product testProduct = new Product("Cherries", 1.00, "USA");

            controller.Create(testProduct);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            Assert.AreEqual(collection[0], testProduct);

        }

        [TestMethod]
        public void DB_RemoveAllEntriesFromDatabase_Test()
        {
            ProductsController controller = new ProductsController(db);
        }

        [TestMethod]
        public void DB_Verify_ProductIds_AutoIncrementing_InDb_Test()
        {
            ProductsController controller = new ProductsController(db);
            Product cherries = new Product("Cherries", 1.00, "USA");
            Product tomatoes = new Product("Tomatoes", 1.00, "USA");

            controller.Create(cherries);
            controller.Create(tomatoes);

            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            Assert.AreEqual(cherries.ProductId + 1, collection[1].ProductId);
        }

        [TestMethod]
        public void DB_DeleteEntry_Test()
        {
			ProductsController controller = new ProductsController(db);
			Product cherries = new Product("Cherries", 1.00, "USA");
			Product tomatoes = new Product("Tomatoes", 1.00, "USA");

            controller.Create(cherries);
            controller.Create(tomatoes);
            controller.DeleteConfirmed(cherries.ProductId);

            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            Assert.AreEqual(tomatoes.Name, collection[0].Name);           
        }
    }
}