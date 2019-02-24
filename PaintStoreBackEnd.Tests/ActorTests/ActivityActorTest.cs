using Moq;
using NUnit.Framework;
using Akka.Actor;
using PaintStore.Application.Actors;
using PaintStore.Application.Actors.Messages;
using PaintStore.Persistence;

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








