using System.Collections.Generic;
using System.Linq;
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

        public UsersResult GetUser(int userId)
        {
            UsersResult usersResult;
            using (var db = paintStoreContext)
            {
                var userToGet = db.Users.First(b => b.Id == userId);
                
                //userToGet.MostUsedCategoryToolName = db.Posts.Where(x => x.UserId == user.Id).GroupBy(x => x.CategoryToolId);

                var toolId = db.Posts.Where(x => x.UserId == userId)
                    .Where(x => x.CategoryToolId != null)
                    .GroupBy(post => post.CategoryToolId)
                    .Select(group => new
                    {
                        ToolId = group.Key,
                        Count =  group.Count()
                    })
                    .OrderByDescending(y => y.Count)
                    .First().ToolId;
                if (toolId != null)
                {
                    usersResult = new UsersResult(userToGet)
                    {
                        MostUsedCategoryToolName = db.CategoryTools.First(x => x.Id == toolId).ToolName
                    };
                }
                else usersResult = new UsersResult(userToGet);
                return usersResult;
            }
        }

        public List<Posts> GetPosts(int userId)
        {
            using (var db = paintStoreContext)
            {
                var images = db.Posts.Where(b => b.UserId == userId);
                return images.ToList();
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
                var userToUptade = paintStoreContext.Users.Where(x => x.Id == user.Id).First();
                if (user.About != null) userToUptade.About = user.About;
                if (user.AvatarImgLink != null) userToUptade.AvatarImgLink = user.AvatarImgLink;
                if (user.BackgroundImgLink != null) userToUptade.BackgroundImgLink = user.BackgroundImgLink;
                if (user.Name != null) userToUptade.Name = user.Name;
                if (user.Link != null) userToUptade.Link = user.Link;
                var count = paintStoreContext.SaveChanges();
                return userToUptade;
            }
        }
    }
}