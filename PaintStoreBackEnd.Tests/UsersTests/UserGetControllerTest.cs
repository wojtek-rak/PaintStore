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
            var mock = InitializeMockContext.InitMock();
            var controller = new UserGetController(mock.Object);
            var result = controller.GetUser(new Users { Link = "kasialink" }).Count();
            var expected = 1;
            Assert.AreEqual(result, expected);
        }
    }
}

