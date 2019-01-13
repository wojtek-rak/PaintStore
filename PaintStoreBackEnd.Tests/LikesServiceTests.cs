using System.Linq;
using backEnd.Exceptions;
using backEnd.Models;
using backEnd.Services;
using Moq;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    public class LikesServiceTests
    {

        [Test]
        public void GetPostLikes_ValidPostId_ReturnsTwo()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            var result = controller.GetPostLikes(1, 1);
            var expected = 2;
            var expected2 = "wyrak";
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
        }

        [Test]
        public void GetPostLikes_NoLoggedUser_ReturnsTwoNoFollowed()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            var result = controller.GetPostLikes(1, 1);
            var expected = 2;
            var expected2 = "wyrak";
            var expected3 = false;
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
            Assert.AreEqual(expected3, result.First().Followed);
        }

        [Test]
        public void AddImageLike_ValidLike_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            controller.AddImageLike(new PostLikes { UserId = 2, PostId = 3  });
            init.mockSetPostLikes.Verify(m => m.Add(It.IsAny<PostLikes>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddImageLike_DuplicateLike_ThrowEx()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            
            Assert.Throws<NegotiatedContentResultException>(() => 
                controller.AddImageLike(new PostLikes { UserId = 2, PostId = 1  })
            );
        }

        [Test]
        public void AddImageLike_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 2;
            var expectedLikeCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().LikeCount;

            var controller = new LikesService(mock.Object);
            controller.AddImageLike(new PostLikes { UserId = 2, PostId = imageId});
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt + 1, mock.Object.Posts.Where(x => x.Id == imageId).First().LikeCount);
        }

        [Test]
        public void RemoveImageLike_ValidLikeId_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            controller.RemoveImageLike(2, 1);
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void RemoveImageLike_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var imageId = 1;
            var expectedLikeCountInt = mock.Object.Posts.Where(x => x.Id == imageId).First().LikeCount;

            var controller = new LikesService(mock.Object);
            controller.RemoveImageLike(2, 1);
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt - 1, mock.Object.Posts.Where(x => x.Id == imageId).First().LikeCount);
        }

        [Test]
        public void GetCommentsLikes_ValidCommentsId_ReturnsTwo()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            var result = controller.GetCommentLikes(1, 1);
            var expected = 2;
            var expected2 = "wyrak";
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
        }
        [Test]
        public void GetCommentsLikes_NoLoggedUser_ReturnsTwoNoFollowed()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            var result = controller.GetCommentLikes(-1, 1);
            var expected = 2;
            var expected2 = "wyrak";
            var expected3 = false;
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
            Assert.AreEqual(expected3, result.First().Followed);
        }
        [Test]
        public void AddCommentLike_ValidLike_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            controller.AddCommentLike(new CommentLikes { UserId = 1, CommentId = 1 });
            init.mockSetCommentLikes.Verify(m => m.Add(It.IsAny<CommentLikes>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddCommentLike_DuplicateLike_ThrowEx()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            
            Assert.Throws<NegotiatedContentResultException>(() => 
                controller.AddCommentLike(new CommentLikes { UserId = 2, CommentId = 1 })
            );
        }

        [Test]
        public void AddCommentLike_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var commentId = 1;
            var expectedLikeCountInt = mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount;

            var controller = new LikesService(mock.Object);
            controller.AddCommentLike(new CommentLikes { UserId = 1, CommentId = commentId });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt + 1, mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount);
        }

        [Test]
        public void RemoveCommentLike_ValidLikeId_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new LikesService(mock.Object);
            controller.RemoveCommentLike(2, 1);
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void RemoveCommentLike_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var commentId = 1;
            var expectedLikeCountInt = mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount;

            var controller = new LikesService(mock.Object);
            controller.RemoveCommentLike(2, 1);
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedLikeCountInt - 1, mock.Object.PostComments.Where(x => x.Id == commentId).First().LikeCount);
        }
    }
}