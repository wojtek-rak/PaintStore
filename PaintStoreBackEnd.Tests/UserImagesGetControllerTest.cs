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
            var mockData = new List<Images> {
                new Images { ImgLink = "link1", ImgSrc = "src1", Date = DateTime.Now, Description = "Desc1", OwnerPath = "kasia" },
                new Images { ImgLink = "link2", ImgSrc = "src2", Date = DateTime.Now, Description = "Desc2", OwnerPath = "kasia" },
                new Images { ImgLink = "link3", ImgSrc = "src3", Date = DateTime.Now, Description = "Desc3", OwnerPath = "zosia" } }.AsQueryable();

            var mockSet = new Mock<DbSet<Images>>();

            mockSet.As<IQueryable<Images>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Images>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Images>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Images>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());


            var mock = new Mock<PaintStoreContext>();
            mock.Setup(x => x.Images)
                .Returns(mockSet.Object);
            var controller = new UserImagesGetController(mock.Object);
            var result = controller.GetImages("kasia").Count();
            var expected = 2;
            Assert.AreEqual(result, expected);
        }
    }
}

