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
    class CommentEditControllerTest
    {
        [Test]
        public void EditCommentTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new CommentEditController(mock.Object);
            var expectedString = "Testowy Komentarz";
            var editedCom = controller.EditComment(new PostComments { Id = 1, Content = expectedString });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedString, editedCom.Content);
        }
    }
}





