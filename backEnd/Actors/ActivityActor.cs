using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using backEnd.Actors.Messages;
using backEnd.Controllers;
using backEnd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace backEnd.Actors
{
    public class ActivityActor : ReceiveActor
    {
        public ActivityActor()
        {

            Receive<StartChildImagesRmMessage>(message =>
            {
                
                foreach (var post in message.ctx.Posts.Where(x => x.UserId == message.UsersToRm.Id))
                {
                    ImageRemoveController.PostRemover(message.ctx, post);
                }

                Sender.Tell(new ChildSucceededMessage());
            });
        }

    }
}


