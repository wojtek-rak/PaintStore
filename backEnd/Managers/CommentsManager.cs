using backEnd.Models;
using System.Linq;

namespace backEnd.Controllers.CategoryControllers
{
    public static class CommentsManager
    {
        public static PostComments CommentLikesCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.PostComments.First(x => x.Id == id);
            countTool.LikeCount += 1;
            return countTool;
        }
        public static PostComments CommentLikesCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.PostComments.First(x => x.Id == id);
            countTool.LikeCount -= 1;
            return countTool;
        }
    }
}

