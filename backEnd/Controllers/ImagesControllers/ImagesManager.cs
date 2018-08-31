using backEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Controllers.CategoryControllers
{
    public class ImagesManager
    {
        public static Posts ImageLikesCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.Where(x => x.Id == id).First();
            countTool.LikeCount += 1;
            return countTool;
        }
        public static Posts ImageLikesCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.Where(x => x.Id == id).First();
            countTool.LikeCount -= 1;
            return countTool;
        }
        public static Posts ImageCommentCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.Where(x => x.Id == id).First();
            countTool.CommentsCount += 1;
            return countTool;
        }
        public static Posts ImageCommentCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.Where(x => x.Id == id).First();
            countTool.CommentsCount -= 1;
            return countTool;
        }
    }
}


