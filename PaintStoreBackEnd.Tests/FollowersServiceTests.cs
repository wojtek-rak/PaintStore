using System.Linq;
using backEnd.Models;
using backEnd.Services;
using Moq;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    public class FollowersServiceTests
    {
        [Test]
        public void GetFollowingUser_ValidUserId_ReturnPosts()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var followersService = new FollowersService(mock.Object);
            var result = followersService.GetFollowingUser(1, 2);
            var expected = 2;
            var expected2 = "Kasia";
            var expected3 = false;
            Assert.AreEqual(expected3, result.First().Followed);
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
        }
        [Test]
        public void GetFollowedUser_ValidUserId_ReturnPosts()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersService(mock.Object);
            var result = controller.GetFollowedUser(2, 1);
            var expected = 2;
            var expected3 = true;
            var expected2 = "wyrak";
            Assert.AreEqual(expected3, result.First().Followed);
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
        }

        [Test]
        public void FollowRemove_FollowRemove_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersService(mock.Object);
            var editedCom = controller.FollowRemove(2, 1);
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Once());
        }

        [Test]
        public void FollowRemove_CountingRemove_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var followID = 1;

            var expectedFollowedCountInt = mock.Object.Users.
                Where(x => x.Id == mock.Object.UserFollowers.
                               Where(y => y.Id == followID).First().FollowedUserId).First().FollowedCount;

            var expectedFollowingCountnewInt = mock.Object.Users.
                Where(x => x.Id == mock.Object.UserFollowers.
                               Where(y => y.Id == followID).First().FollowingUserId).First().FollowingCount;

            var controller = new FollowersService(mock.Object);
            var editedCom = controller.FollowRemove(2, 1);

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedFollowedCountInt - 1, mock.Object.Users.
                Where(x => x.Id == mock.Object.UserFollowers.
                               Where(y => y.Id == followID).First().FollowedUserId).First().FollowedCount);

            Assert.AreEqual(expectedFollowingCountnewInt - 1, mock.Object.Users.
                Where(x => x.Id == mock.Object.UserFollowers.
                               Where(y => y.Id == followID).First().FollowingUserId).First().FollowingCount);
        }

        [Test]
        public void AddFollow_ValidUser_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersService(mock.Object);
            controller.AddFollower(new UserFollowers { FollowedUserId = 2, FollowingUserId = 1 });
            init.mockSetUserFollowers.Verify(m => m.Add(It.IsAny<UserFollowers>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddFollow_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var expectedFollowedCountInt = mock.Object.Users.Where(x => x.Id == 2).First().FollowedCount;
            var expectedFollowingCountnewInt = mock.Object.Users.Where(x => x.Id == 1).First().FollowingCount;
            var controller = new FollowersService(mock.Object);
            controller.AddFollower(new UserFollowers { FollowedUserId = 2, FollowingUserId = 1 });

            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedFollowedCountInt + 1, mock.Object.Users.Where(x => x.Id == 2).First().FollowedCount);
            Assert.AreEqual(expectedFollowingCountnewInt + 1, mock.Object.Users.Where(x => x.Id == 1).First().FollowingCount);

        }
        
    }
}