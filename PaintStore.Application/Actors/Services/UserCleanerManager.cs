using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using PaintStore.Application.Actors.Messages;
using PaintStore.Application.Interfaces;
using PaintStore.Application.Managers;
using PaintStore.Domain.Entities;
using PaintStore.Persistence;

namespace PaintStore.Application.Actors.Services
{
    public interface IUserCleanerManagerStartup
    {
        void RunManager();
    }
    public class UserCleanerManager : IUserCleanerManagerStartup
    {
        public static DateTime LastResetTime;

        private const int SecondCalcActivityInterval = 86400;
        private readonly ICloudinaryService _cloudinaryService;

        private IObservable<long> syncMailObservable;
        private IDisposable subscription = null;

        public UserCleanerManager(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        public void RunManager()
        {
            syncMailObservable = Observable.Interval(TimeSpan.FromSeconds(SecondCalcActivityInterval));
            subscription = syncMailObservable.Subscribe(_ => { ClearAccounts(); });
        }

        public void ClearAccounts()
        {
            IDBContextCreate dbcontexContextCreate = new DBContextCreate();
            

            using (var db = dbcontexContextCreate.CreateContext())
            {
                LastResetTime = DateTime.Now;
                foreach (var user in db.Users)
                {
                    var userToRemove = db.Users.First(x => x.Id == user.Id);

                    if (db.WhiteList.Any(x => x.UserId == userToRemove.Id))
                    {
                        continue;
                    }
                    else
                    {
                        foreach (var post in db.Posts.Where(x => x.UserId == userToRemove.Id))
                        {
                            PostRemover(post.Id,  db);
                        }

                        foreach (var follow in db.UserFollowers.Where(x =>
                            x.FollowedUserId == userToRemove.Id || x.FollowingUserId == userToRemove.Id))
                        {
                            FollowRemove(follow.FollowingUserId, follow.FollowedUserId, db);
                        }

                        foreach (var comments in db.PostComments.Where(x => x.UserId == userToRemove.Id))
                        {
                            CommentRemove(comments, db);
                        }

                        db.Users.Remove(userToRemove);
                    }
                }

                db.SaveChanges();
            }
        }

        //To isolate
        private int PostRemover(int postId, PaintStoreContext db)
        {
                var tempPost = db.Posts.First(x => x.Id == postId);

                UsersManager.UserPostsCountMinus(db, tempPost.UserId);

                var tagsToRemove = db.PostTags.Where(x => x.PostId == postId).ToList();
                foreach (var tagToRemove in tagsToRemove)
                {
                    db.PostTags.Remove(tagToRemove);
                    TagsManager.TagsCountMinus(db, tagToRemove.TagId);
                }

                db.Posts.Remove(db.Posts.First(x => x.Id == postId));
                foreach (var like in db.PostLikes.Where(x => x.PostId == postId))
                {
                    db.PostLikes.Remove(db.PostLikes.First(x => x.Id == like.Id));
                }

                foreach(var comment in db.PostComments.Where(x => x.PostId == postId))
                {
                    db.PostComments.Remove(db.PostComments.First(x => x.Id == comment.Id));
                    foreach (var like in db.CommentLikes.Where(x => x.CommentId == comment.Id))
                    {
                        db.CommentLikes.Remove(db.CommentLikes.First(x => x.Id == like.Id));
                    }
                }

                _cloudinaryService.DeleteImage(tempPost.ImgLink);

                return postId;
        }

        private int FollowRemove(int userIdFollowing, int userIdFollowed, PaintStoreContext db)
        {
                var followId = db.UserFollowers
                    .First(x => x.FollowingUserId == userIdFollowing && x.FollowedUserId == userIdFollowed).Id;

                var tempFollow = db.UserFollowers.First(x => x.Id == followId);
                FollowersManager.UserFollowedCountMinus(db, tempFollow.FollowedUserId);
                FollowersManager.UserFollowingCountMinus(db, tempFollow.FollowingUserId);
                db.UserFollowers.Remove(db.UserFollowers.First(x => x.Id == followId));
                return followId;
        }

        private void CommentRemove(PostComments coment, PaintStoreContext db)
        {
            db.PostComments.Remove(db.PostComments.First(x => x.Id == coment.Id));
            ImagesManager.ImageCommentCountMinus(db, coment.PostId);
            foreach (var like in db.CommentLikes.Where(x => x.CommentId == coment.Id))
            {
                db.CommentLikes.Remove(db.CommentLikes.First(x => x.Id == like.Id));
            } 
        }
    }
}
