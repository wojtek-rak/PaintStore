using System;
using Akka.Actor;
using PaintStore.Application.Actors.Messages;
using PaintStore.Persistence;

namespace PaintStore.Application.Actors
{
    public class ActivityActor : ReceiveActor, IDBContextCreate
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
                using (var db = message.IDBContextCreate.CreateContext())
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

        public PaintStoreContext CreateContext()
        {
            return new PaintStoreContext();
        }
    }
}


