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
    class ImagesAllGetControllerTest
    {
        [Test]
        public void GetAllImage_TheNewest_Test()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new ImagesAllGetController(mock.Object);
            var result2 = controller.GetAllImages("the_newest");
            var result = result2.Select(x => x.Title).First();
            var expected = "Najnowszy";
            Assert.AreEqual(result, expected);
        }


        [Test]
        public void GetAllImage_MostPopular_Test()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new ImagesAllGetController(mock.Object);
            var result2 = controller.GetAllImages("most_popular");
            var result = result2.Select(x => x.Title).First();
            var expected = "Najkomentowszy";
            Assert.AreEqual(result, expected);
        }
    }
}





