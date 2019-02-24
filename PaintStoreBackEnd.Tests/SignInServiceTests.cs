using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using PaintStore.Application.Services;
using PaintStore.Domain.InputModels;
using PaintStoreBackEnd.Tests;

namespace PaintStoreBackEnd.Tests
{
    public class SignInServiceTests
    {
        [Test]
        public void SignIn_ValidEmail_GenerateToken()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var signInService = new SignInService(mock.Object);
            var result = signInService.SignIn(new SignInCommand() { Email = "kasia@kreska.pl"});

            Assert.AreNotEqual(result.Token, null);
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void SignOut_SignedUser_EraseToken()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var signInService = new SignInService(mock.Object);
            var result = signInService.SignOut(new SignOutCommand() { UserId = 3});

            Assert.AreEqual(result, true);
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }

}
