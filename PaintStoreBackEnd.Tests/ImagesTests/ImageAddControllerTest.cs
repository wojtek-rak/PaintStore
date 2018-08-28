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
            var expected = mock.Object.Posts.Count() + 1;

            controller.AddImage(new Posts { Title = "tests", CategoryTypeId = 1, CategoryToolId = 3,  ImgLink = "jakis test link", CreationDate = DateTime.Now, Description = "testowy opis", UserOwnerName = "tester" });
            var result = mock.Object.Posts.Count() + 1;
            Assert.AreEqual(result, expected);
        }
    }
}





