using System.Collections.Generic;
using System.Linq;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public class PostCommentsService : IPostCommentsService
    {
        private readonly PaintStoreContext paintStoreContext;

        public PostCommentsService(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        public List<PostCommentsResult> GetComments(int postId)
        {
            List<PostCommentsResult> commentsResult = new List<PostCommentsResult>();
            using (var db = paintStoreContext)
            {
                var comments = db.PostComments.Where(b => b.PostId == postId).OrderByDescending(x => x.LikeCount);
                foreach (var comment in comments)
                {
                    var userAvatarImgLink = db.Users.First(x => x.Id == comment.UserId).AvatarImgLink;
                    commentsResult.Add(new PostCommentsResult(comment){UserOwnerImgLink = userAvatarImgLink});
                }
                return commentsResult;
            }
        }

        public PostComments AddComment(PostComments comment)
        {
            ImagesManager.ImageCommentCountPlus(paintStoreContext, comment.PostId);
            paintStoreContext.PostComments.Add(comment);
            var count = paintStoreContext.SaveChanges();
            return comment;
        }

        public PostComments EditComment(PostComments comment)
        {
            var commentToUptade = paintStoreContext.PostComments.Where(x => x.Id == comment.Id).First();
            commentToUptade.Content = comment.Content;
            commentToUptade.Edited = true;
            var count = paintStoreContext.SaveChanges();
            return commentToUptade;
        }

        public int CommentRemove(int commentId)
        {
            using (var db = paintStoreContext)
            {
                ImagesManager.ImageCommentCountMinus(db, db.PostComments.
                    Where(x => x.Id == commentId).First().PostId);
                db.PostComments.Remove(db.PostComments.
                    Where(x => x.Id == commentId).First());
                foreach(var like in db.CommentLikes.Where(x => x.CommentId == commentId))
                {
                    db.CommentLikes.Remove(db.CommentLikes.
                        Where(x => x.Id == like.Id).First());
                }
                var count = db.SaveChanges();
            }
            return commentId;
        }
    }
}