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

namespace PaintStoreBackEnd.Tests.Deprecated
{

    [TestFixture]
    class CommentRemoveControllerTest
    {
        [Test]
        public void CommentRemoveTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CommentRemoveController(mock.Object);
            var editedCom = controller.CommentRemove(new PostComments { Id = 1 });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetComments.Verify(m => m.Remove(It.IsAny<PostComments>()), Times.Once());
            init.mockSetCommentLikes.Verify(m => m.Remove(It.IsAny<CommentLikes>()), Times.Exactly(2));
        }

        [Test]
        public void RemoveCommentCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 2;
            var expectedCommentCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount;

            var controller = new CommentRemoveController(mock.Object);
            controller.CommentRemove(new PostComments { Id = 1 });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedCommentCountInt - 1, mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount);
        }
    }
}
