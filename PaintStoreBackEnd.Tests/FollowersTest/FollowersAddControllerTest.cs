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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class FollowersAddControllerTest
    {
        [Test]
        public void AddFollowTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersAddController(mock.Object);
            controller.AddFollower(new UserFollowers { FollowedUserId = 2, FollowingUserId = 1 });
            init.mockSetUserFollowers.Verify(m => m.Add(It.IsAny<UserFollowers>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddFollowCountingTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var expectedFollowedCountInt = mock.Object.Users.Where(x => x.Id == 2).First().FollowedCount;
            var expectedFollowingCountnewInt = mock.Object.Users.Where(x => x.Id == 1).First().FollowingCount;
            var controller = new FollowersAddController(mock.Object);
            controller.AddFollower(new UserFollowers { FollowedUserId = 2, FollowingUserId = 1 });

            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expectedFollowedCountInt + 1, mock.Object.Users.Where(x => x.Id == 2).First().FollowedCount);
            Assert.AreEqual(expectedFollowingCountnewInt + 1, mock.Object.Users.Where(x => x.Id == 1).First().FollowingCount);

        }

    }
}







