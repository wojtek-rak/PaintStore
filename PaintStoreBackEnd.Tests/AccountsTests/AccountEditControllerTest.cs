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

namespace PaintStoreBackEnd.Tests
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
            var expectedString = "Testowy Komentarz";
            var editedUser = controller.EditAccount(new Accounts { Id = 1, Email = expectedString });

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedString, editedUser.Email);
        }
    }
}







