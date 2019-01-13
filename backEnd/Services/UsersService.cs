using System.Collections.Generic;
using System.Linq;
using backEnd.Interfaces;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public class UsersService : IUsersService
    {
        private readonly PaintStoreContext _paintStoreContext;

        public UsersService(PaintStoreContext ctx)
        {
            _paintStoreContext = ctx;
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

        public Users AddUser(Users user)
        {
            using (var db = _paintStoreContext)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }

        public Users EditUser(Users user)
        {
            using (var db = _paintStoreContext)
            {
                //TODO better
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
    }
}