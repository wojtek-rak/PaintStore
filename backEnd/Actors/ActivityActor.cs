using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace backEnd.Actors
{
    public class ActivityActor : ReceiveActor
    {
        public ActivityActor()
        {

            Receive<UpdatePostActivityMessage>(message =>
            {
                using (var db = new PaintStoreContext())
                {
                    //TBD
                    var post = db.Posts.First();
                    post.MixedActivity = post.MixedActivity + 1;
                    
                    //comment in dev
                    //db.SaveChanges();
                }
                Sender.Tell(new ChildSucceededMessage());
            });


            
            
        }


    }
}


