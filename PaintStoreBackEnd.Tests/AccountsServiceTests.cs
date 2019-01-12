using System;
using System.Diagnostics;
using System.Threading;
using backEnd.Models;
using backEnd.Services;
using Moq;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    public class AccountsServiceTests
    {
        [Test]
        public void AddAccount_EmptyAcc_AddAccount()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var accountsService = new AccountsService(mock.Object, new PostService(mock.Object), new FollowersService(mock.Object));
            var editedCom = accountsService.AddAccount(new Accounts { });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetAccount.Verify(m => m.Add(It.IsAny<Accounts>()), Times.Once());
        }

        [Test]
        public void EditAccount_ChangeValues_Changed()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new AccountsService(mock.Object, new PostService(mock.Object), new FollowersService(mock.Object));
            var expectedEmail = "Testowy Komentarz";
            var expectedHash = "hashSW@";
            var editedUser = controller.EditAccount(new Accounts { Id = 1, Email = expectedEmail, PasswordHash = expectedHash });

            mock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(expectedEmail, editedUser.Email);
            Assert.AreEqual(expectedHash, editedUser.PasswordHash);
        }
        [Test]
        public void RemoveAccount_ValidPassword_Remove()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            //var actorSystem = ActorSystem.Create("PSActorSystem");
            //var actorRemove = actorSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
            //var actorSupervisor = actorSystem.ActorOf(Props.Create(() => new SupervisorActor(actorRemove)));

            var controller = new AccountsService(mock.Object, new PostService(mock.Object), new FollowersService(mock.Object));
            var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" });

            //mock.Verify(m => m.SaveChanges(), Times.Once());
            Thread.Sleep(100);
            init.mockSetUsers.Verify(m => m.Remove(It.IsAny<Users>()), Times.Once());
            init.mockSetAccount.Verify(m => m.Remove(It.IsAny<Accounts>()), Times.Once());
            init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Exactly(5));
            init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Exactly(2));
        }

        [Test]
        public void RemoveAccount_WithBadPasswd_NoRemove()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            //var actorSystem = ActorSystem.Create("PSActorSystem");
            //var actorRemove = actorSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
            //var actorSupervisor = actorSystem.ActorOf(Props.Create(() => new SupervisorActor(actorRemove)));

            var controller = new AccountsService(mock.Object, new PostService(mock.Object), new FollowersService(mock.Object));
            //var controller = new AccountRemoveController(mock.Object);
            var removeAccountt = controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sawdasd" });
            var expectedMsg = "Password incorrect";
            Assert.AreEqual(expectedMsg, removeAccountt.PasswordHash);
        }

        [Test]
        public void RemoveAccount_PerformenceTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            //var actorSystem = ActorSystem.Create("PSActorSystem");
            //var actorRemove = actorSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
            //var actorSupervisor = actorSystem.ActorOf(Props.Create(() => new SupervisorActor(actorRemove)));

            var controller = new AccountsService(mock.Object, new PostService(mock.Object), new FollowersService(mock.Object));
            //var controller = new AccountRemoveController(mock.Object);

            var timespan = 10; // can be 0 for result

            Assert.That(Time(() => controller.RemoveAccount(new Accounts { Id = 1, PasswordHash = "!@#sdaAWEDAFSFDSAE" })), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(timespan)));

            //mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetUsers.Verify(m => m.Remove(It.IsAny<Users>()), Times.Once());
            init.mockSetAccount.Verify(m => m.Remove(It.IsAny<Accounts>()), Times.Once());
            init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Exactly(5));
            init.mockSetUserFollowers.Verify(m => m.Remove(It.IsAny<UserFollowers>()), Times.Exactly(2));

        }



        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
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
    }
}