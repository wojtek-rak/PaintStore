using backEnd.Models;
using System.Linq;

namespace backEnd.Controllers.FollowersControllers
{
    public static class FollowersManager
    {
        public static Users UserFollowedCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.First(x => x.Id == id);
            countTool.FollowedCount += 1;
            return countTool;
        }
        public static Users UserFollowedCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.First(x => x.Id == id);
            countTool.FollowedCount -= 1;
            return countTool;
        }
        public static Users UserFollowingCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.First(x => x.Id == id);
            countTool.FollowingCount += 1;
            return countTool;
        }
        public static Users UserFollowingCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.First(x => x.Id == id);
            countTool.FollowingCount -= 1;
            return countTool;
        }
    }
}
