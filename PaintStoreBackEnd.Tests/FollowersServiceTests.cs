using System.Linq;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PaintStore.Application.Services;
using PaintStore.BackEnd;
using PaintStore.Domain.Entities;
using PaintStore.Domain.Exceptions;
using PaintStore.Domain.InputModels;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    public class FollowersServiceTests
    {
        private IMapper mapper;
        [SetUp]
        public void Startup()
        {
            var config = new MapperConfiguration(cfg => { 
                cfg.AddProfile<MappingProfile>();
            });
            mapper = config.CreateMapper();
        }
        [Test]
        public void GetFollowingUser_ValidUserId_ReturnFollows()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var followersService = new FollowersService(mock.Object, mapper);
            var result = followersService.GetFollowingUser(1, 2);
            var expected = 2;
            var expected2 = "Kasia";
            var expected3 = false;
            Assert.AreEqual(expected3, result.First().Followed);
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
        }

        [Test]
        public void GetFollowingUser_NotLoggedUserId_AllNotFollowing()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var followersService = new FollowersService(mock.Object, mapper);
            var result = followersService.GetFollowingUser(-1, 2);
            var expected = 2;
            var expected2 = "Kasia";
            var expected3 = false;
            Assert.AreEqual(expected3, result.First().Followed);
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
        }
        [Test]
        public void GetFollowedUser_ValidUserId_ReturnFollows()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersService(mock.Object, mapper);
            var result = controller.GetFollowedUser(2, 1);
            var expected = 2;
            var expected3 = true;
            var expected2 = "wyrak";
            Assert.AreEqual(expected3, result.First().Followed);
            Assert.AreEqual(expected, result.Count());
            Assert.AreEqual(expected2, result.First().Name);
        }

        [Test]
        public void GetFollowedUser_NotLoggedUserId_AllNotFollowed()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersService(mock.Object, mapper);
            var result = controller.GetFollowedUser(-1, 1);
            var expected = 2;
            var expected3 = false;
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

            var controller = new FollowersService(mock.Object, mapper);
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

            var controller = new FollowersService(mock.Object, mapper);
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

            var controller = new FollowersService(mock.Object, mapper);
            controller.AddFollower(new AddUserFollowersCommand { FollowedUserId = 2, FollowingUserId = 1 });
            init.mockSetUserFollowers.Verify(m => m.Add(It.IsAny<UserFollowers>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void AddFollow_SameUser_ThrowEx()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersService(mock.Object, mapper);
            ;
            Assert.Throws<NegotiatedContentResultException>(() => 
                controller.AddFollower(new AddUserFollowersCommand { FollowedUserId = 2, FollowingUserId = 2 })
                );
        }
        [Test]
        public void AddFollow_ExistingUser_ThrowEx()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersService(mock.Object, mapper);
            ;
            Assert.Throws<NegotiatedContentResultException>(() => 
                controller.AddFollower(new AddUserFollowersCommand { FollowedUserId = 1, FollowingUserId = 2 })
            );
        }

        [Test]
        public void AddFollow_Counting_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var expectedFollowedCountInt = mock.Object.Users.Where(x => x.Id == 2).First().FollowedCount;
            var expectedFollowingCountnewInt = mock.Object.Users.Where(x => x.Id == 1).First().FollowingCount;
            var controller = new FollowersService(mock.Object, mapper);
            controller.AddFollower(new AddUserFollowersCommand { FollowedUserId = 2, FollowingUserId = 1 });

            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedFollowedCountInt + 1, mock.Object.Users.Where(x => x.Id == 2).First().FollowedCount);
            Assert.AreEqual(expectedFollowingCountnewInt + 1, mock.Object.Users.Where(x => x.Id == 1).First().FollowingCount);

        }
        
    }
}