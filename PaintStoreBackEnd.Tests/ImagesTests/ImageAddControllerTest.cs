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
    class ImageAddControllerTest
    {
        [Test]
        public void AddImageTest()
        {
            var mockSet = new Mock<DbSet<Posts>>();

            var mockContext = new Mock<PaintStoreContext>();
            mockContext.Setup(m => m.Posts).Returns(mockSet.Object);

            var controller = new ImageAddController(mockContext.Object);
            controller.AddImage(new Posts { Title = "tests", CategoryTypeId = 1, CategoryToolId = 3, ImgLink = "jakis test link", CreationDate = DateTime.Now, Description = "testowy opis", UserOwnerName = "tester" });
            mockSet.Verify(m => m.Add(It.IsAny<Posts>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}





