using System;
using System.Linq;
using backEnd.Controllers.CommentsControllers;
using backEnd.Models;
using backEnd.Services;
using Moq;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    public class PostCommentsServiceTests
    {
        [Test]
        public void GetComments_ValidPostId_CheckNumber()
        {

            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostCommentsService(mock.Object);
            var result = controller.GetComments(3).Count();
            var expected = 2;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetComments_MostPopular_CheckValid()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostCommentsService(mock.Object);
            var result = controller.GetComments(3).First();
            var expected = 1;
            Assert.AreEqual(expected, result.LikeCount);
        }

        [Test]
        public void CommentRemove_ValidId_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostCommentsService(mock.Object);
            var editedCom = controller.CommentRemove(1);
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetComments.Verify(m => m.Remove(It.IsAny<PostComments>()), Times.Once());
            init.mockSetCommentLikes.Verify(m => m.Remove(It.IsAny<CommentLikes>()), Times.Exactly(2));
        }

        [Test]
        public void RemoveComment_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 2;
            var expectedCommentCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount;

            var controller = new PostCommentsService(mock.Object);
            controller.CommentRemove(1);
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedCommentCountInt - 1, mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount);
        }

        [Test]
        public void EditComment_ValidComment_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostCommentsService(mock.Object);
            var expectedString = "Testowy Komentarz";
            var editedCom = controller.EditComment(new PostComments { Id = 1, Content = expectedString });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedString, editedCom.Content);
        }

        [Test]
        public void AddComment_ValidComment_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostCommentsService(mock.Object);
            controller.AddComment(new PostComments { CreationDate = DateTime.Now, Content = "Testowy Komentarz", PostId = 1, UserId = 1 });
            init.mockSetComments.Verify(m => m.Add(It.IsAny<PostComments>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddComment_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 1;
            var expectedCommentCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount;

            var controller = new PostCommentsService(mock.Object);
            controller.AddComment(new PostComments { UserId = 2, PostId = imageId });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedCommentCountInt + 1, mock.Object.Posts.Where(x => x.Id == imageId).First().CommentsCount);
        }
    }
}