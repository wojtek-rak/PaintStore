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
    class AccountAddControllerTest
    {
        [Test]
        public void AddAccountTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new AccountAddController(mock.Object);
            var editedCom = controller.AddAccount(new Accounts { });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetAccount.Verify(m => m.Add(It.IsAny<Accounts>()), Times.Once());

        }
    }
}






