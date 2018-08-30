using backEnd.Controllers;
using backEnd.Controllers.CategoryControllers;
using backEnd.Controllers.CommentsControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class CategoryGetControllerTest
    {

        [Test]
        public void CategoryToolGetTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CategoryGetAddController(mock.Object);
            var expectedInt = 2;
            var category = controller.GetCategory(new CategoryToFind { ToolName = "aquarels" });

            mock.Verify(m => m.SaveChanges(), Times.Never());
            Assert.AreEqual(expectedInt, category.Id);
        }
        [Test]
        public void CategoryToolGetAddTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CategoryGetAddController(mock.Object);
            var ex = Assert.Throws<InvalidOperationException>(() => controller.GetCategory(new CategoryToFind { ToolName = "xD" }));
            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.That(ex.Message, Is.EqualTo("Sequence contains no elements"));
        }




        [Test]
        public void CategoryTypeGetTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CategoryGetAddController(mock.Object);
            var expectedInt = 2;
            var category = controller.GetCategory(new CategoryToFind { TypeName = "animal" });

            mock.Verify(m => m.SaveChanges(), Times.Never());
            Assert.AreEqual(expectedInt, category.Id);
        }
        [Test]
        public void CategoryTypeGetAddTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CategoryGetAddController(mock.Object);
            var ex = Assert.Throws<InvalidOperationException>(() => controller.GetCategory(new CategoryToFind { TypeName = "xD" }));
            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.That(ex.Message, Is.EqualTo("Sequence contains no elements"));
        }
    }
}

