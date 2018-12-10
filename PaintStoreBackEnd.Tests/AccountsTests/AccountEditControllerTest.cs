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
    class AccountEditControllerTest
    {

        [Test]
        public void EditAccounttTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new AccountEditController(mock.Object);
            var expectedEmail = "Testowy Komentarz";
            var expectedHash = "hashSW@";
            var editedUser = controller.EditAccount(new Accounts { Id = 1, Email = expectedEmail, PasswordHash = expectedHash });

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedEmail, editedUser.Email);
            Assert.AreEqual(expectedHash, editedUser.PasswordHash);
        }
    }
}







