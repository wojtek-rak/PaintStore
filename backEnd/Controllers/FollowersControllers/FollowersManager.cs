using backEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Controllers.FollowersControllers
{
    public static class FollowersManager
    {
        public static Users UserFollowedCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.Where(x => x.Id == id).First();
            countTool.FollowedCount += 1;
            return countTool;
        }
        public static Users UserFollowedCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.Where(x => x.Id == id).First();
            countTool.FollowedCount -= 1;
            return countTool;
        }
        public static Users UserFollowingCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.Where(x => x.Id == id).First();
            countTool.FollowingCount += 1;
            return countTool;
        }
        public static Users UserFollowingCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Users.Where(x => x.Id == id).First();
            countTool.FollowingCount -= 1;
            return countTool;
        }
    }
}
