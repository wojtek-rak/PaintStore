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
            var mock = InitializeMockContext.InitMock();
            var controller = new ImagesGetByCategoryController(mock.Object);
            var result = controller.GetImagesByCategory("both", "krajobraz", "akwarele").Count();
            var expected = 1;
            Assert.AreEqual(result, expected);
        }


        [Test]
        public void GetImagesByCategory_tool_Test()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new ImagesGetByCategoryController(mock.Object);
            var result = controller.GetImagesByCategory("tool", "", "akwarele").Count();
            var expected = 2;
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void GetImagesByCategory_type_Test()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new ImagesGetByCategoryController(mock.Object);
            var result = controller.GetImagesByCategory("type", "krajobraz", "").Count();
            var expected = 2;
            Assert.AreEqual(result, expected);
        }
    }
}




