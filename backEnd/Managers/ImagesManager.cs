using backEnd.Models;
using System.Linq;

namespace backEnd.Controllers.CategoryControllers
{
    public static class ImagesManager
    {
        public static Posts ImageLikesCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.First(x => x.Id == id);
            countTool.LikeCount += 1;
            return countTool;
        }
        public static Posts ImageLikesCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.First(x => x.Id == id);
            countTool.LikeCount -= 1;
            return countTool;
        }
        public static Posts ImageCommentCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.First(x => x.Id == id);
            countTool.CommentsCount += 1;
            return countTool;
        }
        public static Posts ImageCommentCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Posts.First(x => x.Id == id);
            countTool.CommentsCount -= 1;
            return countTool;
        }
    }
}


