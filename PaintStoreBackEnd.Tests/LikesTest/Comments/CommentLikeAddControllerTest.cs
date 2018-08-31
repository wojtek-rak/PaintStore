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
    class CommentLikeAddControllerTest
    {
        [Test]
        public void AddCommentLikeTest()
        {
            var mockSet = new Mock<DbSet<CommentLikes>>();

            var mockContext = new Mock<PaintStoreContext>();
            mockContext.Setup(m => m.CommentLikes).Returns(mockSet.Object);

            var controller = new CommentLikeAddController(mockContext.Object);
            controller.AddCommentLike(new CommentLikes {  });
            mockSet.Verify(m => m.Add(It.IsAny<CommentLikes>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void AddCommentLikeCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var commentId = 1;
            var expectedLikeCountInt = mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount;

            var controller = new CommentLikeAddController(mock.Object);
            controller.AddCommentLike(new CommentLikes { UserId = 1, CommentId = commentId });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt + 1, mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount);
        }
        
    }
}



