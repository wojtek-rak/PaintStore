using System;
using System.Collections.Generic;
using System.Linq;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public class PostCommentsService : IPostCommentsService
    {
        private readonly PaintStoreContext _paintStoreContext;

        public PostCommentsService(PaintStoreContext ctx)
        {
            _paintStoreContext = ctx;
        }
        public List<PostCommentsResult> GetComments(int userId, int postId)
        {
            List<PostCommentsResult> commentsResult = new List<PostCommentsResult>();
            using (var db = _paintStoreContext)
            {
                var comments = db.PostComments.Where(b => b.PostId == postId).OrderByDescending(x => x.LikeCount);
                foreach (var comment in comments)
                {
                    bool liked = db.CommentLikes.Any(x => x.CommentId == comment.Id && x.UserId == userId);
                    var userAvatarImgLink = db.Users.First(x => x.Id == comment.UserId).AvatarImgLink;
                    var userName = db.Users.First(x => x.Id == comment.UserId).Name;
                    commentsResult.Add(new PostCommentsResult(comment){UserOwnerImgLink = userAvatarImgLink, Liked = liked, UserName = userName});
                }
                return commentsResult;
            }
        }

        public PostComments AddComment(PostComments comment)
        {
            ImagesManager.ImageCommentCountPlus(_paintStoreContext, comment.PostId);
            comment.CreationDate = DateTime.Now;
            _paintStoreContext.PostComments.Add(comment);
            _paintStoreContext.SaveChanges();
            return comment;
        }

        public PostComments EditComment(PostComments comment)
        {
            var commentToUptade = _paintStoreContext.PostComments.First(x => x.Id == comment.Id);
            commentToUptade.Content = comment.Content;
            commentToUptade.Edited = true;
            _paintStoreContext.SaveChanges();
            return commentToUptade;
        }

        public int CommentRemove(int commentId)
        {
            using (var db = _paintStoreContext)
            {
                ImagesManager.ImageCommentCountMinus(db, db.PostComments.First(x => x.Id == commentId).PostId);
                db.PostComments.Remove(db.PostComments.First(x => x.Id == commentId));
                foreach(var like in db.CommentLikes.Where(x => x.CommentId == commentId))
                {
                    db.CommentLikes.Remove(db.CommentLikes.First(x => x.Id == like.Id));
                }
                db.SaveChanges();
            }
            return commentId;
        }
    }
}