using backEnd.Controllers;
using backEnd.Controllers.LikeControllers.Comment;
using backEnd.Controllers.LikeControllers.Images;
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
    class CommentLikesGetControllerTest
    {
        [Test]
        public void GetCommentsLikesTest()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new CommentsLikesGetController(mock.Object);
            var result = controller.GetCommentLikes(new PostComments { Id = 1 }).Count();
            var expected = 2;
            Assert.AreEqual(expected, result);
        }
    }
}







