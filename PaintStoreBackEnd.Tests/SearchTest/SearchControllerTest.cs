
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework.Internal;
using PaintStore.BackEnd.Controllers;

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class SearchControllerTest
    {



        [Test]
        public void GetSearch_User_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new SearchController(mock.Object);
            var name = "zosia";
            var searchList = controller.GetSearch(name);
            Assert.AreEqual(searchList.First().Name.ToLower(), name);
            Assert.AreEqual(searchList.Count(), 1);
        }
        [Test]
        public void GetSearch_Tag_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new SearchController(mock.Object);
            var name = "banan";
            var searchList = controller.GetSearch(name);
            Assert.AreEqual(name, searchList.First().TagName);
            Assert.AreEqual(searchList.Count(), 1);
        }
        [Test]
        public void GetSearch_NoElement_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new SearchController(mock.Object);
            var name = "dasasddasfgassad";
            var searchList = controller.GetSearch(name);
            Assert.AreEqual(searchList.Count(), 0);
        }


    }
}
