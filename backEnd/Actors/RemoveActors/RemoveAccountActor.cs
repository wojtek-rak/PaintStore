using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using backEnd.Actors.Messages;
using backEnd.Controllers;
using backEnd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace backEnd.Actors.RemoveActors
{
    public class RemoveAccountActor : ReceiveActor
    {
        private ImageRemoveController _fooService;

        public RemoveAccountActor(PaintStoreContext ctx, ImageRemoveController fooService)
        {
            //_fooService = fooService;

            Receive<StartChildMessage>(message =>
            {
                //_fooService.PostRemove(message.Account)

                Sender.Tell(new ChildSucceededMessage("MyChildActor"));
            });
        }


        public void RemoveAccount(Object message)
        {
            Sender.Tell(new ChildSucceededMessage("MyChildActor"));
        }

    }
}
