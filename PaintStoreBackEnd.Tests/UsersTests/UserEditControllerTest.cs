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
        public void EditUserTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new UserEditController(mock.Object);
            var expectedAvatarImgLink = "Testowy Komentarz";
            var expectedAbout = "abouut";
            var expectedBackgroundImgLink = "bacckgf";
            var expectedName = "namee";
            var expectedLink = "linkdd";
            var editedUser = controller.EditUser(new Users { Id = 1, AvatarImgLink = expectedAvatarImgLink,
                About = expectedAbout, BackgroundImgLink = expectedBackgroundImgLink, Name = expectedName, Link = expectedLink});

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedAvatarImgLink, editedUser.AvatarImgLink);
            Assert.AreEqual(expectedAbout, editedUser.About);
            Assert.AreEqual(expectedBackgroundImgLink, editedUser.BackgroundImgLink);
            Assert.AreEqual(expectedName, editedUser.Name);
            Assert.AreEqual(expectedLink, editedUser.Link);
        }
    }
}






