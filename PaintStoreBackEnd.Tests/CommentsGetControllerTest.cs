using backEnd.Controllers;
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
    class CommentsGetControllerTests
    {
        [Test]
        public void GetCommentTests()
        {

            var mockData = new List<Comments> {
                new Comments { Date = DateTime.Now, Content = "Ale Kom", UserPath = "Zosia", ImgLink = "moj_piesek" },
                new Comments { Date = DateTime.Now, Content = "Ale Kom", UserPath = "Zosia", ImgLink = "moj_pies" } }.AsQueryable();

            var mockSet = new Mock<DbSet<Comments>>();

            mockSet.As<IQueryable<Comments>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<Comments>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<Comments>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<Comments>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());
            

            var mock = new Mock<PaintStoreContext>();
            mock.Setup(x => x.Comments)
                .Returns(mockSet.Object);
            var controller = new CommentsGetController(mock.Object);
            var result = controller.GetComments("moj_piesek").Count();
            var expected = 1;
            Assert.AreEqual(result, expected);
        }
    }
}
