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
    class UserEditControllerTest
    {
        [Test]
        public void EditCommentTest()
        {
            var mock = InitializeMockContext.InitMock();

            var controller = new UserEditController(mock.Object);
            var expectedString = "Testowy Komentarz";
            var editedUser = controller.EditComment(new Users { Id = 1, AvatarImgLink = expectedString });

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedString, editedUser.AvatarImgLink);
        }
    }
}






