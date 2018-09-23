using backEnd.Controllers;
using backEnd.Controllers.CommentsControllers;
using backEnd.Controllers.LikeControllers.Comment;
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using JetBrains.dotMemoryUnit;

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class AccountRemoveControllerTest
    {
        //[Test]
        //public void AccountRemoveTest()
        //{
        //    var init = new InitializeMockContext();
        //    var mock = init.mock;

        //    var controller = new AccountRemoveController(mock.Object);
        //    var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" });

        //    //mock.Verify(m => m.SaveChanges(), Times.Once());
        //    init.mockSetUsers.Verify(m => m.Remove(It.IsAny<Users>()), Times.Once());
        //    init.mockSetAccount.Verify(m => m.Remove(It.IsAny<Accounts>()), Times.Once());
        //    init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Exactly(3));
        //    init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Once());
        //}

        //[Test]
        //public void AccountRemoveWithBadPasswdTest()
        //{
        //    var init = new InitializeMockContext();
        //    var mock = init.mock;

        //    var controller = new AccountRemoveController(mock.Object);
        //    var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sawdasd" });
        //    var expectedMsg = "Password incorrect";
        //    Assert.AreEqual(expectedMsg, removeAccountt.PasswordHash);
        //}

        //[Test]
        //public void AccountRemovePerformenceTest()
        //{
        //    var init = new InitializeMockContext();
        //    var mock = init.mock;

        //    var controller = new AccountRemoveController(mock.Object);

        //    Assert.That(Time(() => controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" })), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0)));

        //    //mock.Verify(m => m.SaveChanges(), Times.Once());
        //    init.mockSetUsers.Verify(m => m.Remove(It.IsAny<Users>()), Times.Once());
        //    init.mockSetAccount.Verify(m => m.Remove(It.IsAny<Accounts>()), Times.Once());
        //    init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Exactly(3));
        //    init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Once());
        //}


        /// <summary>
        /// Memory test
        /// </summary>
        [Test]
        public void AccountRemovePerformenceTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;
            var accSystem = ActorSystem.Create("PSActorSystem");

            var controller = new AccountRemoveController(mock.Object, accSystem, new FollowersRemoveController(mock.Object));

            //var memoryCheckPoint = dotMemory.Check();

            controller.RemoveAccount(new Accounts {Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE"});
            for (int i = 0; i < 10000; i++)
            {
                controller.RemoveAccount(new Accounts {Id = 2, PasswordHash = "!@#sdaAWEDAFdsdsSFDSAE"});
            }
            
            //dotMemory.Check(memory =>
            //{
            //    Assert.That(memory.GetDifference(memoryCheckPoint)
            //        .GetSurvivedObjects()
            //        .GetObjects(where => where.Namespace.Like("backEnd"))
            //        .ObjectsCount, Is.EqualTo(0));
            //});
           
            //controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" })
        }

        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
    }

}


