using System;
using System.Collections.Generic;
using System.Data;
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
        private const int TotalMultiplier = 10000;
        private const int ResNewestHoursMultiplier = 2;
        private const int ResPopularHoursMultiplier = 1;
        private const double ResMixedHoursMultiplier = 1.5;
        private const int CommentsMultipler = 4;
        public ActivityActor()
        {

            Receive<UpdatePostActivityMessage>(message =>
            {
                using (var db = new PaintStoreContext())
                {
                    DateTime now = DateTime.Now;
                    foreach (var post in db.Posts)
                    {
                        var hours = (now - post.CreationDate).TotalHours + 1;
                        var sumActivity = post.CommentsCount * CommentsMultipler + post.LikeCount;

                        var resNewest = (sumActivity / (hours * ResNewestHoursMultiplier)) * TotalMultiplier;
                        var resPopular = (sumActivity / (hours * ResPopularHoursMultiplier)) * TotalMultiplier;
                        var resMixed = (sumActivity / (hours * ResMixedHoursMultiplier)) * TotalMultiplier;
                        
                        post.NewestActivity = (int) resNewest;
                        post.PopularActivity = (int) resPopular;
                        post.MixedActivity = (int) resMixed;
                    }
                    db.SaveChanges();
                }
                Sender.Tell(new ChildSucceededMessage());
            });


            
            
        }


    }
}


