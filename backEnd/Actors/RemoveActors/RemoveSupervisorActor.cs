using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using backEnd.Actors.Messages;
using backEnd.Actors.Services;
using backEnd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace backEnd.Actors.RemoveActors
{
    public class RemoveSupervisorActor : ReceiveActor
    {
        private readonly IChildActorCreator _childActorCreator;
        private IActorRef originalSender;

        public RemoveSupervisorActor(PaintStoreContext ctx, IChildActorCreator childActorCreator)
        {
            Receive<object>(message => RemoveAccount(message));

            _childActorCreator = childActorCreator;
            Receive<StartSupervisorMessage>(message =>
            {
                originalSender = Sender;
                
                var childActor = _childActorCreator.Create<RemoveAccountActor>(Context);

                childActor.Tell(new StartChildMessage(message.Account));

            });
            Receive<ChildSucceededMessage>(message =>
            {

                Console.WriteLine($"{message.FromWho}_ChildSucceededMessage");
                originalSender.Tell(message);
            });
            Receive<ChildFailedMessage>(message =>
            {
                Console.WriteLine($"{message.FromWho}_ChildFailedMessage");
                originalSender.Tell(message);
            });
        }

        public void RemoveAccount(Object message)
        {
            Sender.Tell(new ChildSucceededMessage("MyChildActor"));
        }
    }

}


