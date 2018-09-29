using backEnd.Controllers.ImagesControllers;
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
    class ImagesGetByCategoryControllerTest
    {
    [Test]
        public void GetImagesByCategory_Both_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new ImagesGetByCategoryController(mock.Object);
            var result = controller.GetImagesByCategory(new Message { Properties = "both", CategoryType = "animal", CategoryTool = "aquarels" }).Count();
            var expected = 1;
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void GetImagesByCategory_tool_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new ImagesGetByCategoryController(mock.Object);
            var result = controller.GetImagesByCategory(new Message { Properties = "tool", CategoryType = "", CategoryTool = "pencil" }).Count();
            var expected = 2;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetImagesByCategory_type_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new ImagesGetByCategoryController(mock.Object);
            var result = controller.GetImagesByCategory(new Message { Properties = "type", CategoryType = "animal", CategoryTool = "" }).Count();
            var expected = 2;
            Assert.AreEqual(expected, result);
        }
    }
}




