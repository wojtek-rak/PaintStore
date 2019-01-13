using backEnd.Models;
using System.Linq;

namespace backEnd.Controllers.CategoryControllers
{
    public class UsersManager
    {
        public static Users UserPostsCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.Where(x => x.Id == id).First();
            countTool.PostsCount += 1;
            return countTool;
        }
        public static Users UserPostsCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.Where(x => x.Id == id).First();
            countTool.PostsCount -= 1;
            return countTool;
        }
    }
}




