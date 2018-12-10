using backEnd.Controllers;
using backEnd.Controllers.CommentsControllers;
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
    class CommentAddControllerTest
    {
        [Test]
        public void AddCommentTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CommentAddController(mock.Object);
            controller.AddComment(new PostComments { CreationDate = DateTime.Now, Content = "Testowy Komentarz", PostId = 1, UserId = 1 });
            init.mockSetComments.Verify(m => m.Add(It.IsAny<PostComments>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddCommentCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 1;
            var expectedCommentCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount;

            var controller = new CommentAddController(mock.Object);
            controller.AddComment(new PostComments { UserId = 2, PostId = imageId });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedCommentCountInt + 1, mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount);
        }
    }
}


