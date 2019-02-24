using System.Linq;
using PaintStore.Domain.Entities;
using PaintStore.Persistence;

namespace PaintStore.Application.Managers
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

