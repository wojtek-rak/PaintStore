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
    class AccountRemoveControllerTest
    {
        [Test]
        public void AccountRemoveTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new AccountRemoveController(mock.Object);
            var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" });
            //mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetUsers.Verify(m => m.Remove(It.IsAny<Users>()), Times.Once());
            init.mockSetAccount.Verify(m => m.Remove(It.IsAny<Accounts>()), Times.Once());
            init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Exactly(3));
            init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Once());
        }

        [Test]
        public void AccountRemoveWithBadPasswdTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new AccountRemoveController(mock.Object);
            var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sawdasd" });
            var expectedMsg = "Password incorect";
            Assert.AreEqual(expectedMsg, removeAccountt.PasswordHash);
        }
    }
}


