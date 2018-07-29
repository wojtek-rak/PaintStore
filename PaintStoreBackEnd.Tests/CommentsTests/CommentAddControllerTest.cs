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
    class CommentAddControllerTest
    {
        [Test]
        public void AddCommentTest()
        {
            var mock = InitializeMockContext.InitMock();
            var controller = new CommentAddController(mock.Object);
            var expected = mock.Object.Comments.Count() + 1;

            controller.AddComment(new Comments { Date = DateTime.Now, Content = "Testowy Komentarz", ImgLink = "jakis test link", UserPath = "tester" });

            var result = mock.Object.Comments.Count() + 1;
            Assert.AreEqual(result, expected);
        }
    }
}


