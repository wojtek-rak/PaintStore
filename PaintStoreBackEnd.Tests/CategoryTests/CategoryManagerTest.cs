using backEnd.Controllers;
using backEnd.Controllers.CategoryControllers;
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
    class CategoryManagerTest
    {

        [Test]
        public void CategoryToolAddTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;



            var category = CategoryManager.CategoryToolAdd(mock.Object, new CategoryToFind { ToolName = "aquarels" });

            init.mockSetCategoryTools.Verify(m => m.Add(It.IsAny<CategoryTools>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void CategoryTypeAddTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var category = CategoryManager.CategoryTypeAdd(mock.Object, new CategoryToFind { TypeName = "animal" });

            init.mockSetCategoryTypes.Verify(m => m.Add(It.IsAny<CategoryTypes>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}



