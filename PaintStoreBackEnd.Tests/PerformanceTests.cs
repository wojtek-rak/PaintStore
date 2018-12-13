using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using backEnd.Controllers.SearchControllers;
using backEnd.Models.ResultsModels;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests.Performance
{
    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        public void SearchPerformenceTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new SearchController(mock.Object);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SET TIME <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            var timespan = 1; // can be 0 for result
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SET TIME <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            IEnumerable<SearchResult> searchList = controller.GetSearch( "zosia");

            Assert.That(Time(() => MultiplyMehod(controller)), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(timespan)));

            Assert.AreEqual(searchList.First().Name, "Zosia");
            Assert.AreEqual(searchList.Count(), 1);
            //Assert.AreEqual(searchList.Skip(1).First().TypeName, "poZosiase");
        }

        private IEnumerable<SearchResult> MultiplyMehod(SearchController controller)
        {
            for (int i = 0; i < 99; i++) controller.GetSearch( "zosia");
            return controller.GetSearch("zosia");
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