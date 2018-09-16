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
    class ImageEditControllerTest
    {
        [Test]
        public void EditPostTest()
        {
            var mock = InitializeMockContext.InitMock();

            var controller = new ImageEditController(mock.Object);
            var expectedInt = 2;
            var expectedDesc = "exp";
            var expectedTitle = "Titl";
            var editedPost = controller.EditPost(new Posts { Id = 1, CategoryToolId = expectedInt, Description = expectedDesc, Title = expectedTitle});
            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedInt, editedPost.CategoryToolId);
            Assert.AreEqual(expectedTitle, editedPost.Title);
            Assert.AreEqual(expectedDesc, editedPost.Description);
            Assert.AreEqual(null, editedPost.CategoryTypeId);
        }

        [Test]
        public void EditPostCountingToolTestTest()
        {
            var mock = InitializeMockContext.InitMock();

            var controller = new ImageEditController(mock.Object);
            var expectedInt = 1;
            var expectedCountInt = mock.Object.CategoryTools.Where(x => x.Id == 2).First().Count;
            var expectedCountnewInt = mock.Object.CategoryTools.Where(x => x.Id == expectedInt).First().Count;
            var editedPost = controller.EditPost(new Posts { Id = 3, CategoryToolId = expectedInt });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedInt, editedPost.CategoryToolId);
            Assert.AreEqual(expectedCountInt - 1, mock.Object.CategoryTools.Where(x => x.Id == 2).First().Count, 1);
            Assert.AreEqual(expectedCountnewInt + 1,mock.Object.CategoryTools.Where(x => x.Id == expectedInt).First().Count);

        }
        [Test]
        public void EditPostCountingTypeTestTest()
        {
            var mock = InitializeMockContext.InitMock();

            var controller = new ImageEditController(mock.Object);
            var expectedInt = 1;
            var expectedCountInt = mock.Object.CategoryTypes.Where(x => x.Id == 2).First().Count;
            var expectedCountnewInt = mock.Object.CategoryTypes.Where(x => x.Id == expectedInt).First().Count;
            var editedPost = controller.EditPost(new Posts { Id = 3, CategoryTypeId = expectedInt });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedInt, editedPost.CategoryTypeId);
            Assert.AreEqual(expectedCountInt -1, mock.Object.CategoryTypes.Where(x => x.Id == 2).First().Count);
            Assert.AreEqual(expectedCountnewInt + 1, mock.Object.CategoryTypes.Where(x => x.Id == expectedInt).First().Count);
        }

        
    }
}

