using System.Linq;
using PaintStore.Domain.Entities;
using PaintStore.Persistence;

namespace PaintStore.Application.Managers
{
    public static class UsersManager
    {
        public static Users UserPostsCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.First(x => x.Id == id);
            countTool.PostsCount += 1;
            return countTool;
        }
        public static Users UserPostsCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.First(x => x.Id == id);
            countTool.PostsCount -= 1;
            return countTool;
        }
    }
}




