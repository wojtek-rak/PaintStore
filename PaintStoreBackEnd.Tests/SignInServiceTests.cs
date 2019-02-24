using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PaintStore.Application.Services;
using PaintStore.Domain.InputModels;
using PaintStoreBackEnd.Tests;

namespace PaintStoreBackEnd.Tests
{
    public class SignInServiceTests
    {
        [Test]
        public void GetFollowingUser_ValidUserId_ReturnFollows()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var signInService = new SignInService(mock.Object);
            var result = signInService.SignIn(new SignInCommand() { Email = "Wojtek@wp.pl", Password = "123456"});

            Assert.Fail();
        }

        [Test]
        public void GetFollowingUser_NotLoggedUserId_AllNotFollowing()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var signInService = new SignInService(mock.Object);
            var result = signInService.SignOut(new SignOutCommand() { UserId = 3});

            Assert.Fail();
        }
    }

}
