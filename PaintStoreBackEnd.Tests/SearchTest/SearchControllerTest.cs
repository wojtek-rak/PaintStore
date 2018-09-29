using backEnd.Controllers;
using backEnd.Controllers.CommentsControllers;
using backEnd.Controllers.LikeControllers.Comment;
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
using backEnd.Controllers.SearchControllers;
using NUnit.Framework.Internal;

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class SearchControllerTest
    {

        [Test]
        public void SearchTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new SearchController(mock.Object);
            var searchList = controller.GetSearch(new Users { Name = "zosia" });
            Assert.AreEqual(searchList.First().Name, "Zosia");
            Assert.AreEqual(searchList.Count(), 3);
            Assert.AreEqual(searchList.Skip(1).First().TypeName, "poZosiase");
        }
    }
}

