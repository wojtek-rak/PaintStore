using backEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Controllers.CategoryControllers
{
    public class CommentsManager
    {
        public static PostComments CommentLikesCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.PostComments.Where(x => x.Id == id).First();
            countTool.LikeCount += 1;
            return countTool;
        }
        public static PostComments CommentLikesCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.PostComments.Where(x => x.Id == id).First();
            countTool.LikeCount += 1;
            return countTool;
        }
    }
}

