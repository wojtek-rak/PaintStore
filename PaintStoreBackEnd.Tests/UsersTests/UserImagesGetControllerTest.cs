using backEnd.Controllers;
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
    class UserImagesGetControllerTest
    {
        [Test]
        public void GetImagesTest()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new UserImagesGetController(mock.Object);
            var result = controller.GetImages(new Users { Id = 2 }).Count();
            var expected = 2;
            Assert.AreEqual(expected, result);
        }
    }
}

