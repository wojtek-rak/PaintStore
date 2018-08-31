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
    class CommentLikeRemoveControllerTest
    {
        [Test]
        public void RemoveCommentLikeTest()
        {
            var mock = InitializeMockContext.InitMock();

            var controller = new CommentLikeRemoveController(mock.Object);
            controller.RemoveCommentLike(new CommentLikes { Id = 1 });
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void RemoveCommentLikeCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var commentId = 1;
            var expectedLikeCountInt = mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount;

            var controller = new CommentLikeRemoveController(mock.Object);
            controller.RemoveCommentLike(new CommentLikes { Id = 1 });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt - 1, mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount);
        }
    }
}



