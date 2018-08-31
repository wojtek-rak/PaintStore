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
    class ImagesFollowingGetControllerTest
    {
        [Test]
        public void ImageRemoveTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new ImagesFollowingGetController(mock.Object);
            var editedCom = controller.GetImages(new Users { Id = 2 });

            Assert.AreEqual(4, editedCom.First().Id);
        }
    }
}


