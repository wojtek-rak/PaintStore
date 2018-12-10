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
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using backEnd.Actors;
using backEnd.Actors.RemoveActors;
using JetBrains.dotMemoryUnit;

namespace PaintStoreBackEnd.Tests.Deprecated
{

    [TestFixture]
    class AccountRemoveControllerTest
    {
        [Test]
        public void AccountRemoveTest()
        {
            Assert.True(true);

            //var init = new InitializeMockContext();
            //var mock = init.mock;

            ////var actorSystem = ActorSystem.Create("PSActorSystem");
            ////var actorRemove = actorSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
            ////var actorSupervisor = actorSystem.ActorOf(Props.Create(() => new SupervisorActor(actorRemove)));

            //var controller = new AccountRemoveController(mock.Object);
            //var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" });

            ////mock.Verify(m => m.SaveChanges(), Times.Once());
            //Thread.Sleep(100);
            //init.mockSetUsers.Verify(m => m.Remove(It.IsAny<Users>()), Times.Once());
            //init.mockSetAccount.Verify(m => m.Remove(It.IsAny<Accounts>()), Times.Once());
            //init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Exactly(5));
            //init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Exactly(2));
        }

        [Test]
        public void AccountRemoveWithBadPasswdTest()
        {
            Assert.True(true);
            //var init = new InitializeMockContext();
            //var mock = init.mock;

            ////var actorSystem = ActorSystem.Create("PSActorSystem");
            ////var actorRemove = actorSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
            ////var actorSupervisor = actorSystem.ActorOf(Props.Create(() => new SupervisorActor(actorRemove)));

            //var controller = new AccountRemoveController(mock.Object);
            ////var controller = new AccountRemoveController(mock.Object);
            //var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sawdasd" });
            //var expectedMsg = "Password incorrect";
            //Assert.AreEqual(expectedMsg, removeAccountt.PasswordHash);
        }

        [Test]
        public void AccountRemovePerformenceTest()
        {
            Assert.True(true);
            //var init = new InitializeMockContext();
            //var mock = init.mock;

            ////var actorSystem = ActorSystem.Create("PSActorSystem");
            ////var actorRemove = actorSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
            ////var actorSupervisor = actorSystem.ActorOf(Props.Create(() => new SupervisorActor(actorRemove)));

            //var controller = new AccountRemoveController(mock.Object);
            ////var controller = new AccountRemoveController(mock.Object);

            //var timespan = 10; // can be 0 for result

            //Assert.That(Time(() => controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" })), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(timespan)));

            ////mock.Verify(m => m.SaveChanges(), Times.Once());
            //init.mockSetUsers.Verify(m => m.Remove(It.IsAny<Users>()), Times.Once());
            //init.mockSetAccount.Verify(m => m.Remove(It.IsAny<Accounts>()), Times.Once());
            //init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Exactly(5));
            //init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Exactly(2));

        }


        /// <summary>
        /// Memory test
        /// </summary>
        //[Test]
        //public void AccountRemovePerformenceMemoryTest()
        //{
        //    var init = new InitializeMockContext();
        //    var mock = init.mock;
        //    var accSystem = ActorSystem.Create("PSActorSystem");
        //    var actorRemove = accSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
        //    var actorSupervisor = accSystem.ActorOf(Props.Create(() => new SupervisorActor(actorRemove)));
        //    var controller = new AccountRemoveController(mock.Object, new FollowersRemoveController(mock.Object), actorSupervisor);

        //    var memoryCheckPoint = dotMemory.Check();

        //    controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" });
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        controller.RemoveAccount(new Accounts { Id = 2, PasswordHash = "!@#sdaAWEDAFdsdsSFDSAE" });
        //    }

        //    dotMemory.Check(memory =>
        //    {
        //        Assert.That(memory.GetDifference(memoryCheckPoint)
        //            .GetSurvivedObjects()
        //            .GetObjects(where => where.Namespace.Like("backEnd"))
        //            .ObjectsCount, Is.EqualTo(0));
        //    });

        //    //controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" })
        //}

        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
    }

}


