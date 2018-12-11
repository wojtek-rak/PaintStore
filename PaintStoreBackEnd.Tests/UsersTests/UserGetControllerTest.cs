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

namespace PaintStoreBackEnd.Tests.Deprecated
{

    [TestFixture]
    class UserGetControllerTest
    {
        //[Test]
        //public void GetUserTest()
        //{
        //    var init = new InitializeMockContext();
        //    var mock = init.mock;

        //    var controller = new UserGetController(mock.Object);
        //    var result = controller.GetUser(new Users { Id = 1 }).Count();
        //    var expected = 1;
        //    Assert.AreEqual(result, expected);
        //}

        //[Test]
        //public void GetUserCategoryToolTest()
        //{
        //    var init = new InitializeMockContext();
        //    var mock = init.mock;

        //    var controller = new UserGetController(mock.Object);
        //    var result = controller.GetUser(new Users {Id = 1});
        //    var expected = "pencil";
        //    Assert.AreEqual(result.First().MostUsedCategoryToolName, expected);
        //}
    }
}

