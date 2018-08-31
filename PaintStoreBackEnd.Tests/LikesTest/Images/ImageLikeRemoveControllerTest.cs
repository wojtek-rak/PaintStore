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

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class ImageLikeRemoveControllerTest
    {
        [Test]
        public void RemoveImageLikeTest()
        {
            var mock = InitializeMockContext.InitMock();

            var controller = new ImageLikeRemoveController(mock.Object);
            controller.RemoveImageLike(new PostLikes { Id = 1 });
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void RemoveImageLikeCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 1;
            var expectedLikeCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().LikeCount;

            var controller = new ImageLikeRemoveController(mock.Object);
            controller.RemoveImageLike(new PostLikes { Id = 1 });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt - 1, mock.Object.PostComments.Where(x => x.Id == imageId).First().LikeCount);
        }
    }
}




