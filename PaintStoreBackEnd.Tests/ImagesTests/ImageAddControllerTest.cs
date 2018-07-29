using backEnd.Controllers;
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
    class ImageAddControllerTest
    {
        [Test]
        public void AddImageTest()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new ImageAddController(mock.Object);
            var expected = mock.Object.Images.Count() + 1;

            controller.AddImage(new Images { Title = "tests", Category_type = "portrettest", Category_tool = "pisaki test",  ImgLink = "jakis test link", ImgSrc = "test.jpg", Date = DateTime.Now, Description = "testowy opis", OwnerPath = "tester" });
            var result = mock.Object.Images.Count() + 1;
            Assert.AreEqual(result, expected);
        }
    }
}





