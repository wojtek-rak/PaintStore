using backEnd.Controllers;
using backEnd.Controllers.CommentsControllers;
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
    class ImageLikeAddControllerTest
    {
        [Test]
        public void AddImageLikeTest()
        {
            var mockSet = new Mock<DbSet<PostLikes>>();

            var mockContext = new Mock<PaintStoreContext>();
            mockContext.Setup(m => m.PostLikes).Returns(mockSet.Object);

            var controller = new ImageLikeAddController(mockContext.Object);
            controller.AddImageLike(new PostLikes { });
            mockSet.Verify(m => m.Add(It.IsAny<PostLikes>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void RemoveImageLikeCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 1;
            var expectedLikeCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().LikeCount;

            var controller = new ImageLikeAddController(mock.Object);
            controller.AddImageLike(new PostLikes { UserId = 2, PostId = imageId});
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt + 1, mock.Object.PostComments.Where(x => x.Id == imageId).First().LikeCount);
        }
    }
}





