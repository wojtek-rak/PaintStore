using System.Collections.Generic;
using System.Linq;
using PaintStore.Application.Interfaces;
using PaintStore.Application.Managers;
using PaintStore.Domain.Entities;
using PaintStore.Domain.Exceptions;
using PaintStore.Domain.ResultsModels;
using PaintStore.Persistence;

namespace PaintStore.Application.Services
{
    public class LikesService : ILikesService
    {
        private readonly PaintStoreContext _paintStoreContext;

        public LikesService(PaintStoreContext ctx)
        {
            _paintStoreContext = ctx;
        }
        public List<LikesResult> GetPostLikes(int loggedUserId, int postId)
        {
            using (var db = _paintStoreContext)
            {
                var postLikesList = new List<LikesResult>();
                var likes = db.PostLikes.Where(b => b.PostId == postId).
                    OrderByDescending(postLikes => db.Users.First(user => user.Id == postLikes.UserId).FollowedCount);

                foreach (var like in likes)
                {
                    var user = db.Users.First(x => x.Id == like.UserId);
                    bool followed =  loggedUserId != -1 && db.UserFollowers.Any(x => x.FollowedUserId == user.Id && x.FollowingUserId == loggedUserId);
                    postLikesList.Add(new LikesResult(like.UserId, user.Name, user.AvatarImgLink, followed));
                }
                return postLikesList;
            }
        }

        public PostLikes AddImageLike(PostLikes like)
        {
            using (var db = _paintStoreContext)
            {
                if ((db.PostLikes.Any(x => x.PostId == like.PostId && x.UserId == like.UserId)))
                {
                    throw new NegotiatedContentResultException();
                }
                ImagesManager.ImageLikesCountPlus(db, like.PostId);
                db.PostLikes.Add(like);
                db.SaveChanges();
                return like;
            }
        }

        public int RemoveImageLike(int userId, int postId)
        {
            using (var db = _paintStoreContext)
            {
                var likeId = db.PostLikes.First(x => x.PostId == postId && x.UserId == userId).Id;

                ImagesManager.ImageLikesCountMinus(db, db.PostLikes.First(x => x.Id == likeId).PostId);
                db.PostLikes.Remove(db.PostLikes.First(x => x.Id == likeId));
                db.SaveChanges();
                return likeId;
            }
        }

        public List<LikesResult> GetCommentLikes(int loggedUserId, int commentId)
        {
            using (var db = _paintStoreContext)
            {
                var commentLikesList = new List<LikesResult>();
                var likes = db.CommentLikes.Where(b => b.CommentId == commentId)
                    .OrderByDescending(commentLikes => db.Users.First(user => user.Id == commentLikes.UserId).FollowedCount);
                foreach (var like in likes)
                {
                    var user = db.Users.First(x => x.Id == like.UserId);
                    bool followed =  loggedUserId != -1 && db.UserFollowers.Any(x => x.FollowedUserId == user.Id && x.FollowingUserId == loggedUserId);
                    commentLikesList.Add(new LikesResult(like.UserId, user.Name, user.AvatarImgLink, followed));
                }
                return commentLikesList;
            }
        }

        public CommentLikes AddCommentLike(CommentLikes like)
        {
            using (var db = _paintStoreContext)
            {
                if ((db.CommentLikes.Any(x => x.CommentId == like.CommentId && x.UserId == like.UserId)))
                {
                    throw new NegotiatedContentResultException();
                }
                CommentsManager.CommentLikesCountPlus(db, like.CommentId);
                db.CommentLikes.Add(like);
                db.SaveChanges();
                return like;
            }
        }

        public int RemoveCommentLike(int userId, int commentId)
        {
            using (var db = _paintStoreContext)
            {
                var likeId = db.CommentLikes.First(x => x.CommentId == commentId && x.UserId == userId).Id;

                CommentsManager.CommentLikesCountMinus(db, db.CommentLikes.First(x => x.Id == likeId).CommentId);
                db.CommentLikes.Remove(db.CommentLikes.First(x => x.Id == likeId));
                db.SaveChanges();
                return likeId;
            }
        }
    }
}