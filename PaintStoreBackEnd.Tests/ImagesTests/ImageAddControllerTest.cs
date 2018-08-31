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
using System.Linq.Expressions;
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
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new ImageAddController(mock.Object);
            controller.AddImage(new Posts { Title = "tests", CategoryTypeId = 1, CategoryToolId = 1, ImgLink = "jakis test link", CreationDate = DateTime.Now, Description = "testowy opis", UserOwnerName = "tester" });
            init.mockSetImages.Verify(m => m.Add(It.IsAny<Posts>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        //[Test]
        //public void AddImageCategoryToolCountingTest()
        //{
        //    var init = new InitializeMockContext();
        //    var mock = init.mock;

        //    var controller = new ImageAddController(mock.Object);
        //    controller.AddImage(new Posts { Title = "tests", CategoryTypeId = 1, CategoryToolId = 1, ImgLink = "jakis test link", CreationDate = DateTime.Now, Description = "testowy opis", UserOwnerName = "tester" });
        //    init.mockSetImages.Verify(m => m.Add(It.IsAny<Posts>()), Times.Once());
        //    mock.Verify(m => m.SaveChanges(), Times.Once());
        //}
    }
}





