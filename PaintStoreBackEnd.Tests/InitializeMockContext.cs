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
    class InitializeMockContext
    {
        public static Mock<PaintStoreContext> InitMock()
            {
            var mock = new Mock<PaintStoreContext>();

            var mockDataUsers = new List<Users> {
                new Users { Name = "kasia", Email = "costam@xd.pl", Password = "tu jakis donoskink chyba", Link = "kasialink", AvatarSrc = "appa", BackgroundSrc = "bappa", About = "xD"},
                new Users { Name = "tosia", Email = "costam@2d.pl", Password = "2u jakis donoskink chyba", Link = "tosialink", AvatarSrc = "2appa", BackgroundSrc = "2bappa", About = "2xD"}}.AsQueryable();

            var mockDataComments = new List<Comments> {
                new Comments { Date = DateTime.Now, Content = "Ale Kom", UserPath = "Zosia", ImgLink = "link2" },
                new Comments { Date = DateTime.Now, Content = "Ale Kom", UserPath = "Zosia", ImgLink = "link3" },
                new Comments { Date = DateTime.Now, Content = "Ale Kom", UserPath = "Zosia", ImgLink = "link3" } }.AsQueryable();

            var mockDataImages = new List<Images> {
                new Images { Title = "zaden", Category_type = "krajobraz", Category_tool = "akwarele", ImgLink = "link1", ImgSrc = "src1", Date = DateTime.Today, Description = "Desc1", OwnerPath = "kasialink" },
                new Images { Title = "Najnowszy", Category_type = "portret", Category_tool = "akwarele", ImgLink = "link2", ImgSrc = "src2", Date = DateTime.Now, Description = "Desc2", OwnerPath = "tosialink" },
                new Images { Title = "Najkomentowszy", Category_type = "krajobraz", Category_tool = "pisaki", ImgLink = "link3", ImgSrc = "src3", Date = DateTime.Today, Description = "Desc3", OwnerPath = "kasialink" } }.AsQueryable();

            var mockSetUsers = new Mock<DbSet<Users>>();
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(mockDataUsers.Provider);
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(mockDataUsers.Expression);
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(mockDataUsers.ElementType);
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(mockDataUsers.GetEnumerator());

            var mockSetComments = new Mock<DbSet<Comments>>();
            mockSetComments.As<IQueryable<Comments>>().Setup(m => m.Provider).Returns(mockDataComments.Provider);
            mockSetComments.As<IQueryable<Comments>>().Setup(m => m.Expression).Returns(mockDataComments.Expression);
            mockSetComments.As<IQueryable<Comments>>().Setup(m => m.ElementType).Returns(mockDataComments.ElementType);
            mockSetComments.As<IQueryable<Comments>>().Setup(m => m.GetEnumerator()).Returns(mockDataComments.GetEnumerator());

            var mockSetImages = new Mock<DbSet<Images>>();
            mockSetImages.As<IQueryable<Images>>().Setup(m => m.Provider).Returns(mockDataImages.Provider);
            mockSetImages.As<IQueryable<Images>>().Setup(m => m.Expression).Returns(mockDataImages.Expression);
            mockSetImages.As<IQueryable<Images>>().Setup(m => m.ElementType).Returns(mockDataImages.ElementType);
            mockSetImages.As<IQueryable<Images>>().Setup(m => m.GetEnumerator()).Returns(mockDataImages.GetEnumerator());

            mock.Setup(x => x.Users)
                            .Returns(mockSetUsers.Object);
            mock.Setup(x => x.Comments)
                            .Returns(mockSetComments.Object);
            mock.Setup(x => x.Images)
                            .Returns(mockSetImages.Object);

            return mock;
            }

        public static Mock<DbSet<T>> InitMockDbSet<T>(T objectToAdd) where T : class
        {
            var mockData = new List<T> { objectToAdd }.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());
            return mockSet;
        }
    }
}
