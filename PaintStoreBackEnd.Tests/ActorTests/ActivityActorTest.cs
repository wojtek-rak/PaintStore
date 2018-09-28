using backEnd.Controllers;
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
using Akka.Actor;
using backEnd.Actors;
using backEnd.Actors.Messages;
using backEnd.Actors.RemoveActors;

namespace PaintStoreBackEnd.Tests.ActorTests
{
    
    [TestFixture]
    class ActivityActorTest
    {
        [Test]
        public void CreateActorTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var mockIDBContext = new Mock<IDBContextCreate>();
            mockIDBContext.Setup(x => x.CreateContext())
                .Returns(mock.Object);

            var actorSystem = ActorSystem.Create("PSActorSystem");
            var actorActivity = actorSystem.ActorOf(Props.Create(() => new ActivityActor()));

            var task = actorActivity.Ask(new UpdatePostActivityMessage(mockIDBContext.Object));
            task.Wait();
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}








