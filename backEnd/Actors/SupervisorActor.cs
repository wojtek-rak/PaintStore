using Akka.Actor;
using backEnd.Actors.Messages;
using backEnd.Models;

namespace backEnd.Actors.RemoveActors
{
    public class SupervisorActor : ReceiveActor
    {
        private IActorRef originalSender;
        //private IActorRef removeAccountActorRef;
        private IActorRef activityActorRef;
        private IDBContextCreate idbcontexContextCreate;

        public SupervisorActor(IActorRef activActorRef)
        {
            idbcontexContextCreate = new DBContextCreate();
            activityActorRef = activActorRef;

            Receive<UpdatePostActivityMessage>(message =>
            {
                originalSender = Sender;
                activActorRef.Tell(new UpdatePostActivityMessage(idbcontexContextCreate));
            });

            //Receive<SupervisorMessage_RmImages>(message =>
            //{
            //    Sender.Tell(new ChildSucceededMessage());
            //    originalSender = Sender;
            //    removeAccountActorRef.Tell(new StartChildImagesRmMessage(message.UserToRm, message.ctx));

            //});
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


