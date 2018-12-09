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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backEnd.Controllers.SearchControllers;
using backEnd.Models.ResultsModels;
using NUnit.Framework.Internal;

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class SearchControllerTest
    {

        [Test]
        public void SearchPerformenceTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new SearchController(mock.Object);

            var timespan = 0; // can be 0 for result

            IEnumerable<SearchResult> searchList = controller.GetSearch( "zosia");

            Assert.That(Time(() => MultiplyMehod(controller)), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(timespan)));

            Assert.AreEqual(searchList.First().Name, "Zosia");
            Assert.AreEqual(searchList.Count(), 3);
            Assert.AreEqual(searchList.Skip(1).First().TypeName, "poZosiase");
        }

        private IEnumerable<SearchResult> MultiplyMehod(SearchController controller)
        {
            for (int i = 0; i < 99; i++) controller.GetSearch( "zosia");
            return controller.GetSearch("zosia");
        }

        [Test]
        public void SearchTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new SearchController(mock.Object);
            var searchList = controller.GetSearch("zosia");
            Assert.AreEqual(searchList.First().Name, "Zosia");
            Assert.AreEqual(searchList.Count(), 3);
            Assert.AreEqual(searchList.Skip(1).First().TypeName, "poZosiase");
        }

        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
    }
}

