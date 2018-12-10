using System.Linq;
using backEnd.Models;
using backEnd.Services;
using Moq;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    public class UsersServiceTests
    {
        [Test]
        public void GetUser_ValidUserId_ReturnUser()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var usersService = new UsersService(mock.Object);
            var result = usersService.GetUser(1);
            var expected = "Kasia";
            Assert.AreEqual(result.Name, expected);
        }

        [Test]
        public void GetUser_MostCategoryTool_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new UsersService(mock.Object);
            var result = controller.GetUser(1);
            var expected = "pencil";
            Assert.AreEqual(result.MostUsedCategoryToolName, expected);
        }

        [Test]
        public void EditUser_AllProperties_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new UsersService(mock.Object);
            var expectedAvatarImgLink = "Testowy Komentarz";
            var expectedAbout = "abouut";
            var expectedBackgroundImgLink = "bacckgf";
            var expectedName = "namee";
            var expectedLink = "linkdd";
            var editedUser = controller.EditUser(new Users { Id = 1, AvatarImgLink = expectedAvatarImgLink,
                About = expectedAbout, BackgroundImgLink = expectedBackgroundImgLink, Name = expectedName, Link = expectedLink});

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedAvatarImgLink, editedUser.AvatarImgLink);
            Assert.AreEqual(expectedAbout, editedUser.About);
            Assert.AreEqual(expectedBackgroundImgLink, editedUser.BackgroundImgLink);
            Assert.AreEqual(expectedName, editedUser.Name);
            Assert.AreEqual(expectedLink, editedUser.Link);
        }

        [Test]
        public void AddUser_ValidUser_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new UsersService(mock.Object);
            var editedCom = controller.AddUser(new Users {  });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetUsers.Verify(m => m.Add(It.IsAny<Users>()), Times.Once());
        }

        [Test]
        public void GetImages_UserImages_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new UsersService(mock.Object);
            var result = controller.GetPosts(2).Count();
            var expected = 1;
            Assert.AreEqual(expected, result);
        }
    }
}