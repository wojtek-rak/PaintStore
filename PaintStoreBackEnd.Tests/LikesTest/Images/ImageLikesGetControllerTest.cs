using backEnd.Controllers;
using backEnd.Controllers.LikeControllers.Images;
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
    class ImageLikesGetControllerTest
    {
        [Test]
        public void GetImageLikesTest()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new ImageLikesGetController(mock.Object);
            var result = controller.GetImageLikes(new Posts { Id = 1 }).Count();
            var expected = 2;
            Assert.AreEqual(expected, result);
        }
    }
}





