using Akka.Actor;
using PaintStore.Application.Actors.Messages;
using PaintStore.Persistence;

namespace PaintStore.Application.Actors
{
    public class SupervisorActor : ReceiveActor
    {
        private IActorRef originalSender;
        private readonly IActorRef _activityActorRef;
        private readonly IDBContextCreate idbcontexContextCreate;
       

        public SupervisorActor(IActorRef activActorRef)
        {
            idbcontexContextCreate = new DBContextCreate();
            _activityActorRef = activActorRef;

            Receive<UpdatePostActivityMessage>(message =>
            {
                originalSender = Sender;
                activActorRef.Tell(new UpdatePostActivityMessage(idbcontexContextCreate));
            });
            Receive<ChildSucceededMessage>(message =>
            {
                originalSender.Tell(message);
            });
            Receive<ChildFailedMessage>(message =>
            {
                originalSender.Tell(message);
            });
        }

    }

}


