using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AccountRemoveController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
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
                    var postRemover = new ImageRemoveController(db);

                    foreach(var post in db.Posts.Where(x => x.UserId == userToRemove.Id))
                    {
                        postRemover.PostRemove(post);
                    }

                    var followRemover = new FollowersRemoveController(db);
                    foreach (var follow in db.UserFollowers.
                        Where(x => x.FollowedUserId == userToRemove.Id || x.FollowingUserId == userToRemove.Id))
                    {
                        followRemover.FollowRemove(follow);
                    }
                    var userRemove = db.Users.Remove(userToRemove);
                    var accountRemove = db.Accounts.Remove(accountToRemove);

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