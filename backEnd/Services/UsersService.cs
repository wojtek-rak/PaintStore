using System.Collections.Generic;
using System.Linq;
using backEnd.Interfaces;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public class UsersService : IUsersService
    {
        private readonly PaintStoreContext paintStoreContext;

        public UsersService(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        public UsersResult GetUser(int loggedUserId, int userId)
        {
            UsersResult usersResult;
            using (var db = paintStoreContext)
            {
                var userToGet = db.Users.First(b => b.Id == userId);
                
                //userToGet.MostUsedCategoryToolName = db.Posts.Where(x => x.UserId == user.Id).GroupBy(x => x.CategoryToolId);
                bool followed = false;
                if (db.UserFollowers.Any(x => x.FollowedUserId == userToGet.Id && x.FollowingUserId == loggedUserId)) followed = true;

                usersResult = new UsersResult(userToGet){Followed = followed};
                return usersResult;
            }
        }

        public List<PostsResults> GetPosts(int userId, string message)
        {
            List<PostsResults> postsResult = new List<PostsResults>();
            using (var db = paintStoreContext)
            {
                IQueryable<IPosts> images = null;
                if (message == "most_popular")
                {
                    images = db.Posts.Where(z => z.UserId == userId).OrderByDescending(y => y.PopularActivity);
                }
                if (message == "the_newest")
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
            using (var db = paintStoreContext)
            {
                paintStoreContext.Users.Add(user);
                var count = paintStoreContext.SaveChanges();
                return user;
            }
        }

        public Users EditUser(Users user)
        {
            using (var db = paintStoreContext)
            {
                //todo better
                var userToUpdate = paintStoreContext.Users.First(x => x.Id == user.Id);
                if (user.About != null) userToUpdate.About = user.About;
                if (user.AvatarImgLink != null) userToUpdate.AvatarImgLink = user.AvatarImgLink;
                if (user.BackgroundImgLink != null) userToUpdate.BackgroundImgLink = user.BackgroundImgLink;
                if (user.Name != null) userToUpdate.Name = user.Name;
                if (user.Link != null) userToUpdate.Link = user.Link;
                var count = paintStoreContext.SaveChanges();
                return userToUpdate;
            }
        }
    }
}