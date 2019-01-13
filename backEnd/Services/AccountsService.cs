using System;
using System.Linq;
using backEnd.Models;

namespace backEnd.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly PaintStoreContext _paintStoreContext;
        private readonly IPostsService _postsService;
        private readonly IFollowersService _followersService;
        public AccountsService(PaintStoreContext ctx, IPostsService postsService, IFollowersService followersService)
        {
            _paintStoreContext = ctx;
            _postsService = postsService;
            _followersService = followersService;
        }
        public Accounts AddAccount(Accounts account)
        {
            using (var db = _paintStoreContext)
            {
                account.CreationDate = DateTime.Now;
                db.Accounts.Add(account);
                db.SaveChanges();
                return account;
            }
        }

        public Accounts EditAccount(Accounts account)
        {
            using (var db = _paintStoreContext)
            {
                var accountToUpdate = db.Accounts.First(x => x.Id == account.Id);
                if (account.Email != null) accountToUpdate.Email = account.Email;
                if (account.PasswordHash != null) accountToUpdate.PasswordHash = account.PasswordHash;
                db.SaveChanges();
                return accountToUpdate;
            }
        }

        public Accounts RemoveAccount(Accounts account)
        {
            using (var db = _paintStoreContext)
            {
                var accountToRemove = db.Accounts.First(x => x.Id == account.Id);
                if (account.PasswordHash == db.Accounts.First(x => x.Id == account.Id).PasswordHash)
                {
                    var userToRemove = db.Users.First(x => x.AccountId == accountToRemove.Id);

                    foreach (var post in db.Posts.Where(x => x.UserId == userToRemove.Id))
                    {
                        _postsService.PostRemover(post.Id);
                    }

                    foreach (var follow in db.UserFollowers.
                        Where(x => x.FollowedUserId == userToRemove.Id || x.FollowingUserId == userToRemove.Id))
                    {
                        _followersService.FollowRemove(follow.FollowingUserId, follow.FollowedUserId);
                    }
                    db.Users.Remove(userToRemove);
                    db.Accounts.Remove(accountToRemove);

                    db.SaveChanges();
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
