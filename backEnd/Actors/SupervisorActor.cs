using Akka.Actor;
using System;
using backEnd.Actors.Messages;
using backEnd.Models;

namespace backEnd.Actors.RemoveActors
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


