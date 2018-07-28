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
    class UserGetControllerTest
    {
        [Test]
        public void GetUserTest()
        {
            var mockData = new List<Users> {
                new Users { Name = "kasia1", Email = "costam@xd.pl", Password = "tu jakis donoskink chyba", Link = "xD", AvatarSrc = "appa", BackgroundSrc = "bappa", About = "xD"},
                new Users { Name = "kasia2", Email = "costam@2d.pl", Password = "2u jakis donoskink chyba", Link = "2xD", AvatarSrc = "2appa", BackgroundSrc = "2bappa", About = "2xD"}}.AsQueryable();

        var mockSet = new Mock<DbSet<Users>>();

            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());


            var mock = new Mock<PaintStoreContext>();
            mock.Setup(x => x.Users)
                .Returns(mockSet.Object);
            var controller = new UserGetController(mock.Object);
            var result = controller.GetUser("xD").Count();
            var expected = 1;
            Assert.AreEqual(result, expected);
        }
    }
}

