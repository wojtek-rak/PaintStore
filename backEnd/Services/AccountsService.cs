using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers;
using backEnd.Models;

namespace backEnd.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly PaintStoreContext paintStoreContext;
        private readonly IPostsService _postsService;
        private readonly IFollowersService _followersService;
        public AccountsService(PaintStoreContext ctx, IPostsService postsService, IFollowersService followersService)
        {
            paintStoreContext = ctx;
            _postsService = postsService;
            _followersService = followersService;
        }
        public Accounts AddAccount(Accounts account)
        {
            using (var db = paintStoreContext)
            {
                account.CreationDate = DateTime.Now;
                db.Accounts.Add(account);
                var count = db.SaveChanges();
                return account;
            }
        }

        public Accounts EditAccount(Accounts account)
        {
            using (var db = paintStoreContext)
            {
                //todo better
                var accountToUpdate = db.Accounts.First(x => x.Id == account.Id);
                if (account.Email != null) accountToUpdate.Email = account.Email;
                if (account.PasswordHash != null) accountToUpdate.PasswordHash = account.PasswordHash;
                var count = db.SaveChanges();
                return accountToUpdate;
            }
        }

        public Accounts RemoveAccount(Accounts account)
        {
            using (var db = paintStoreContext)
            {
                var accountToRemove = db.Accounts.First(x => x.Id == account.Id);
                if (account.PasswordHash == db.Accounts.First(x => x.Id == account.Id).PasswordHash)
                {
                    var userToRemove = db.Users.First(x => x.AccountId == accountToRemove.Id);

                    //var task = removeSupervisorActor.Ask(new SupervisorMessage_RmImages(userToRemove, db));

                    foreach (var post in db.Posts.Where(x => x.UserId == userToRemove.Id))
                    {
                        _postsService.PostRemover(post.Id);
                    }

                    foreach (var follow in db.UserFollowers.
                        Where(x => x.FollowedUserId == userToRemove.Id || x.FollowingUserId == userToRemove.Id))
                    {
                        _followersService.FollowRemove(follow.FollowingUserId, follow.FollowedUserId);
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
