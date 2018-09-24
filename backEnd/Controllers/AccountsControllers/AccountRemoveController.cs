using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.Core;
using Akka.Util.Internal;
using Autofac;
using backEnd.Actors;
using backEnd.Actors.Messages;
using backEnd.Actors.RemoveActors;
using backEnd.Controllers.LikeControllers.Comment;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.CommentsControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountRemoveController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;
        private readonly ActorSystem actorSystem;
        //private  IActorRef removeSupervisorActor;

        public AccountRemoveController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
            //this.removeSupervisorActor = removeSupervisorActor;
        }

        [HttpPost]
        public Accounts RemoveAccount([FromBody] Accounts account)
        {
            using (var db = paintStoreContext)
            {

                var accountToRemove = db.Accounts.First(x => x.Id == account.Id);
                if (account.PasswordHash == db.Accounts.First(x => x.Id == account.Id).PasswordHash)
                {
                    var userToRemove = db.Users.First(x => x.AccountId == accountToRemove.Id);

                    //var task = removeSupervisorActor.Ask(new SupervisorMessage_RmImages(userToRemove, db));

                    var postRemover = new ImageRemoveController(db);

                    foreach (var post in db.Posts.Where(x => x.UserId == userToRemove.Id))
                    {
                        ImageRemoveController.PostRemover(paintStoreContext, post);
                    }

                    foreach (var follow in db.UserFollowers.
                        Where(x => x.FollowedUserId == userToRemove.Id || x.FollowingUserId == userToRemove.Id))
                    {
                        FollowersRemoveController.FollowRemover(paintStoreContext, follow);
                    }
                    var userRemove = db.Users.Remove(userToRemove);
                    var accountRemove = db.Accounts.Remove(accountToRemove);

                    //task.Wait();
                    var count = db.SaveChanges();
                    return accountToRemove;
                }
                else
                {
                    return new Accounts { PasswordHash = "Password incorrect" };
                }
            }
        }
    }
}