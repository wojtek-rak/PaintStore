using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintStore.Application.Helpers;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.Entities;
using PaintStore.Domain.InputModels;
using PaintStore.Domain.Interfaces;
using PaintStore.Domain.ResultsModels;
using PaintStore.Persistence;

namespace PaintStore.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly PaintStoreContext _paintStoreContext;
        private readonly IPostsService _postsService;
        private readonly IFollowersService _followersService;

        public UsersService(PaintStoreContext ctx, IPostsService postsService, IFollowersService followersService)
        {
            _paintStoreContext = ctx;
            _postsService = postsService;
            _followersService = followersService;
        }

        public UsersResult GetUser(int loggedUserId, int userId)
        {
            using (var db = _paintStoreContext)
            {
                var userToGet = db.Users.First(b => b.Id == userId);
                
                bool followed = db.UserFollowers.Any(x => x.FollowedUserId == userToGet.Id && x.FollowingUserId == loggedUserId);

                var usersResult = new UsersResult(userToGet){Followed = followed};
                return usersResult;
            }
        }

        public List<PostsResults> GetPosts(int userId, string message)
        {
            List<PostsResults> postsResult = new List<PostsResults>();
            using (var db = _paintStoreContext)
            {
                IQueryable<IPosts> images = null;
                if (message == "most_popular")
                {
                    images = db.Posts.Where(z => z.UserId == userId).OrderByDescending(y => y.PopularActivity);
                }
                else if (message == "the_newest")
                {
                    images = db.Posts.Where(z => z.UserId == userId).OrderByDescending(x => x.CreationDate);
                }
                foreach (var image in images)
                {
                    var userOwnerImgLink = db.Users.First(x => x.Id == userId).AvatarImgLink;
                    postsResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
                }
                return postsResult;
            }
        }

        public Users AddUser(AddUserCommand user)
        {
            using (var db = _paintStoreContext)
            {
                var newUser = new Users() {Email = user.Email, Name = user.Name, Link = user.Name.ToLower(), About = ""};
                newUser.PasswordSoil = CredentialsHelpers.CreateSalt();
                var  encoding = new ASCIIEncoding();
                var soil = encoding.GetBytes(newUser.PasswordSoil);
                var password = encoding.GetBytes(user.Password);
                newUser.PasswordHash = System.Text.Encoding.UTF8.GetString(CredentialsHelpers.GenerateSaltedHash(password, soil));
                db.Users.Add(newUser);
                db.SaveChanges();
                return newUser;
            }
        }

        public Users EditUser(Users user)
        {
            using (var db = _paintStoreContext)
            {
                var userToUpdate = _paintStoreContext.Users.First(x => x.Id == user.Id);
                if (user.About != null) userToUpdate.About = user.About;
                if (user.AvatarImgLink != null) userToUpdate.AvatarImgLink = user.AvatarImgLink;
                if (user.BackgroundImgLink != null) userToUpdate.BackgroundImgLink = user.BackgroundImgLink;
                if (user.Name != null) userToUpdate.Name = user.Name;
                if (user.Link != null) userToUpdate.Link = user.Link;
                _paintStoreContext.SaveChanges();
                return userToUpdate;
            }
        }

        public Users EditUserCredentials(Users account)
        {
            using (var db = _paintStoreContext)
            {
                var accountToUpdate = db.Users.First(x => x.Id == account.Id);
                if (account.Email != null) accountToUpdate.Email = account.Email;
                if (account.PasswordHash != null) accountToUpdate.PasswordHash = account.PasswordHash;
                db.SaveChanges();
                return accountToUpdate;
            }
        }

        public Users RemoveUser(Users account)
        {
            using (var db = _paintStoreContext)
            {
                var userToRemove = db.Users.First(x => x.Id == account.Id);
                if (account.PasswordHash == db.Users.First(x => x.Id == account.Id).PasswordHash)
                {

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

                    db.SaveChanges();
                    return userToRemove;
                }
                else
                {
                    return new Users() { PasswordHash = "Password incorrect" };
                }
            }
        }

        
    }
}