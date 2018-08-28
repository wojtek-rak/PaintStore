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
            //Email = "costam@xd.pl", Password = "tu jakis donoskink chyba", 
            //Email = "costam@2d.pl", Password = "2u jakis donoskink chyba",
            var mockDataUsers = new List<Users> {
                new Users { Id = 1, Name = "Kasia", Link = "kasialink", AvatarImgLink = "appa", BackgroundImgLink = "bappa", About = "xD", AccountId = 1},
                new Users { Id = 2, Name = "Zosia", Link = "tosialink", AvatarImgLink = "2appa", BackgroundImgLink = "2bappa", About = "2xD", AccountId = 2}}.AsQueryable();

            var mockDataComments = new List<PostComments> {
                new PostComments { Id = 1, CreationDate = DateTime.Now, Content = "Ale Kom", PostId = 2, UserId = 2 },
                new PostComments { Id = 2, CreationDate = DateTime.Now, Content = "Ale Kom", PostId = 3, UserId = 2  },
                new PostComments { Id = 3, CreationDate = DateTime.Now, Content = "Ale Kom", PostId = 3, UserId = 2  } }.AsQueryable();

            var mockDataImages = new List<Posts> {
                new Posts { Id = 1, Title = "zaden", CategoryTypeId = 1, CategoryToolId = 2, ImgLink = "link1", CreationDate = DateTime.Today, Description = "Desc1", UserOwnerName = "Zosia", UserId = 2 },
                new Posts { Id = 2, Title = "Najnowszy", CategoryTypeId = 2, CategoryToolId = 2, ImgLink = "link2", CreationDate = DateTime.Now, Description = "Desc2", UserOwnerName = "Kasia", UserId = 1 },
                new Posts { Id = 3,  Title = "Najkomentowszy", CategoryTypeId = 2, CategoryToolId = 2, ImgLink = "link3", CreationDate = DateTime.Today, Description = "Desc3", UserOwnerName = "Zosia", UserId = 2  } }.AsQueryable();

            var mockSetUsers = new Mock<DbSet<Users>>();
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(mockDataUsers.Provider);
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(mockDataUsers.Expression);
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(mockDataUsers.ElementType);
            mockSetUsers.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(mockDataUsers.GetEnumerator());

            var mockSetComments = new Mock<DbSet<PostComments>>();
            mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.Provider).Returns(mockDataComments.Provider);
            mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.Expression).Returns(mockDataComments.Expression);
            mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.ElementType).Returns(mockDataComments.ElementType);
            mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.GetEnumerator()).Returns(mockDataComments.GetEnumerator());

            var mockSetImages = new Mock<DbSet<Posts>>();
            mockSetImages.As<IQueryable<Posts>>().Setup(m => m.Provider).Returns(mockDataImages.Provider);
            mockSetImages.As<IQueryable<Posts>>().Setup(m => m.Expression).Returns(mockDataImages.Expression);
            mockSetImages.As<IQueryable<Posts>>().Setup(m => m.ElementType).Returns(mockDataImages.ElementType);
            mockSetImages.As<IQueryable<Posts>>().Setup(m => m.GetEnumerator()).Returns(mockDataImages.GetEnumerator());

            mock.Setup(x => x.Users)
                            .Returns(mockSetUsers.Object);
            mock.Setup(x => x.PostComments)
                            .Returns(mockSetComments.Object);
            mock.Setup(x => x.Posts)
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
