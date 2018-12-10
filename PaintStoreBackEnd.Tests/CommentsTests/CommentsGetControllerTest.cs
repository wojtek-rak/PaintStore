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
    class CommentsGetControllerTests
    {
        [Test]
        public void GetCommentTests()
        {

            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CommentsGetController(mock.Object);
            var result = controller.GetComments(new Posts { Id = 3 }).Count();
            var expected = 2;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetCommentMostPopularTests()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CommentsGetController(mock.Object);
            var result = controller.GetComments(new Posts { Id = 3 }).First();
            var expected = 1;
            Assert.AreEqual(expected, result.LikeCount);
        }
    }
}
