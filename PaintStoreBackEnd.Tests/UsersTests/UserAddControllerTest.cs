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
    class UserAddControllerTest
    {
        [Test]
        public void AddUserTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new UserAddController(mock.Object);
            var editedCom = controller.AddUser(new Users {  });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetUsers.Verify(m => m.Add(It.IsAny<Users>()), Times.Once());


        }
    }
}





