using System.Collections.Generic;
using System.Linq;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public class LikesService : ILikesService
    {
        private readonly PaintStoreContext paintStoreContext;

        public LikesService(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        public List<LikesResult> GetPostLikes(int postId)
        {
            using (var db = paintStoreContext)
            {
                var postLikesList = new List<LikesResult>();
                var likes = db.PostLikes.Where(b => b.PostId == postId).
                    OrderByDescending(postLikes => db.Users.First(user => user.Id == postLikes.UserId).FollowedCount);

                foreach (var like in likes)
                {
                    var user = db.Users.First(x => x.Id == like.UserId);
                    postLikesList.Add(new LikesResult(like.UserId, user.Name, user.AvatarImgLink));
                }
                return postLikesList;
            }
        }

        public PostLikes AddImageLike(PostLikes like)
        {
            ImagesManager.ImageLikesCountPlus(paintStoreContext, like.PostId);
            paintStoreContext.PostLikes.Add(like);
            var count = paintStoreContext.SaveChanges();
            return like;
        }

        public int RemoveImageLike(int userId, int postId)
        {
            using (var db = paintStoreContext)
            {
                var likeId = db.PostLikes.First(x => x.PostId == postId && x.UserId == userId).Id;

                    ImagesManager.ImageLikesCountMinus(paintStoreContext, paintStoreContext.PostLikes.
                        Where(x => x.Id == likeId).First().PostId);
                paintStoreContext.PostLikes.Remove(paintStoreContext.PostLikes.
                    Where(x => x.Id == likeId).First());
                var count = paintStoreContext.SaveChanges();
                return likeId;
            }
        }

        public List<LikesResult> GetCommentLikes(int commentId)
        {
            using (var db = paintStoreContext)
            {
                var commentLikesList = new List<LikesResult>();
                var likes = db.CommentLikes.Where(b => b.CommentId == commentId)
                    .OrderByDescending(commentLikes => db.Users.First(user => user.Id == commentLikes.UserId).FollowedCount);
                foreach (var like in likes)
                {
                    var user = db.Users.First(x => x.Id == like.UserId);
                    commentLikesList.Add(new LikesResult(like.UserId, user.Name, user.AvatarImgLink));
                }
                return commentLikesList;
            }
        }

        public CommentLikes AddCommentLike(CommentLikes like)
        {
            CommentsManager.CommentLikesCountPlus(paintStoreContext, like.CommentId);
            paintStoreContext.CommentLikes.Add(like);
            var count = paintStoreContext.SaveChanges();
            return like;
        }

        public int RemoveCommentLike(int userId, int commentId)
        {
            using (var db = paintStoreContext)
            {
                var likeId = db.CommentLikes.First(x => x.CommentId == commentId && x.UserId == userId).Id;

                CommentsManager.CommentLikesCountMinus(paintStoreContext, paintStoreContext.CommentLikes.
                    Where(x => x.Id == likeId).First().CommentId);
                paintStoreContext.CommentLikes.Remove(paintStoreContext.CommentLikes.
                    Where(x => x.Id == likeId).First());
                var count = paintStoreContext.SaveChanges();
                return likeId;
            }
        }
    }
}