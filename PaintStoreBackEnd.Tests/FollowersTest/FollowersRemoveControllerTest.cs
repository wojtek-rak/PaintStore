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
    class FollowersRemoveControllerTest
    {
        [Test]
        public void FollowRemoveTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new FollowersRemoveController(mock.Object);
            var editedCom = controller.FollowRemove(new UserFollowers { Id = 1 });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Once());
        }

        [Test]
        public void FollowCountingRemoveTest()
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

            var controller = new FollowersRemoveController(mock.Object);
            var editedCom = controller.FollowRemove(new UserFollowers { Id = followID });

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedFollowedCountInt - 1, mock.Object.Users.
                Where(x => x.Id == mock.Object.UserFollowers.
                Where(y => y.Id == followID).First().FollowedUserId).First().FollowedCount);

            Assert.AreEqual(expectedFollowingCountnewInt - 1, mock.Object.Users.
                Where(x => x.Id == mock.Object.UserFollowers.
                Where(y => y.Id == followID).First().FollowingUserId).First().FollowingCount);
        }
    }
}


