using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using backEnd.Controllers;
using backEnd.Models;
using backEnd.Services;
using Moq;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    class PostsServiceTests
    {
        [Test]
        public void GetPost_ValidPostId_ReturnPost()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var postService = new PostService(mock.Object);
            var result = postService.GetPost(1);
            var expected = "link1";
            Assert.AreEqual(expected, result.ImgLink);
        }

        [Test]
        public void GetFollowingPost_UserWithPosts_PostList()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostService(mock.Object);
            var editedCom = controller.GetFollowingPosts(2);

            Assert.AreEqual(4, editedCom.First().Id);
        }
        
        [Test]
        public void GetAllPosts_TheNewest_MostRecent()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostService(mock.Object);
            var result2 = controller.GetAllPosts( "the_newest");
            var result = result2.Select(x => x.Title).First();
            var expected = "comm bez lików";
            Assert.AreEqual(result, expected);
        }


        [Test]
        public void GetAllPosts_MostPopular_MostPopular()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostService(mock.Object);
            var result2 = controller.GetAllPosts("most_popular");
            var result = result2.Select(x => x.Title).First();
            var expected = "Najkomentowszy      ";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PostRemover_PostWithCommentsLikes_RemoveEvrything()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostService(mock.Object);
            var editedCom = controller.PostRemover(4);
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Once());
            init.mockSetPostLikes.Verify(m => m.Remove(It.IsAny<PostLikes>()), Times.Once());
            init.mockSetComments.Verify(m => m.Remove(It.IsAny<PostComments>()), Times.Once());
            init.mockSetCommentLikes.Verify(m => m.Remove(It.IsAny<CommentLikes>()), Times.Never());
        }

        [Test]
        public void PostRemover_ImageCounting_ReduceCountByOne()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var userId = 1;
            var expectedImageCountInt = mock.Object.Users.Where(x => x.Id == userId).First().PostsCount;

            var controller = new PostService(mock.Object);
            controller.PostRemover(1);
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedImageCountInt - 1, mock.Object.Users.Where(x => x.Id == userId).First().PostsCount);
        }

        [Test]
        public void AddImageTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new PostService(mock.Object);
            controller.AddImage(new Posts { Title = "tests", CategoryTypeId = 1, CategoryToolId = 1, ImgLink = "jakis test link", CreationDate = DateTime.Now, Description = "testowy opis", UserId = 1 });
            init.mockSetImages.Verify(m => m.Add(It.IsAny<Posts>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }


        [Test]
        public void AddImageCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var userId = 1;
            var expectedImageCountInt = mock.Object.Users.Where(x => x.Id == userId).First().PostsCount;

            var controller = new PostService(mock.Object);
            controller.AddImage(new Posts { UserId = userId });
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedImageCountInt + 1, mock.Object.Users.Where(x => x.Id == userId).First().PostsCount);
        }

    }
}
