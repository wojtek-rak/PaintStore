using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.LikeControllers.Comment;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public AccountsController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost("AddAccount")]
        public IActionResult AddAccount([FromBody] Accounts account)
        {
            paintStoreContext.Accounts.Add(account);
            var count = paintStoreContext.SaveChanges();
            return Ok(account);
        }

        [HttpPut("EditAccount")]
        public IActionResult EditAccount([FromBody] Accounts account)
        {
            //todo better
            var accountToUpdate = paintStoreContext.Accounts.First(x => x.Id == account.Id);
            if (account.Email != null) accountToUpdate.Email = account.Email;
            if (account.PasswordHash != null) accountToUpdate.PasswordHash = account.PasswordHash;
            var count = paintStoreContext.SaveChanges();
            return Ok(accountToUpdate);
        }

        [HttpPost("DeleteAccount")]
        public IActionResult RemoveAccount([FromBody] Accounts account)
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
                        PostsController.PostRemover(paintStoreContext, post.Id);
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
                    return Ok(accountToRemove);
                }
                else
                {
                    return Ok(new Accounts { PasswordHash = "Password incorrect" });
                }
            }
        }
    }
}