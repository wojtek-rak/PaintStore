using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Interfaces;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public class PostService : IPostsService
    {
        private readonly PaintStoreContext paintStoreContext;

        public PostService(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        public PostDetailsResult GetPost(int postId)
        {
            using (var db = paintStoreContext)
            {
                var post = db.Posts.First(b => b.Id == postId);
                var tagsIds = db.PostTags.Where(x => x.PostId == postId).Select(y => y.TagId).ToList();

                var tagsList = db.Tags.Where(tag =>
                    tagsIds.Contains(tag.Id)).Select(x => x.TagName).ToList();

                //var categoryTypeName = post.CategoryTypeId == null ? null : 
                //    db.CategoryTypes.First(x => x.Id == post.CategoryTypeId).TypeName;
                //var categoryToolName = post.CategoryToolId == null ? null : 
                //    db.CategoryTools.First(x => x.Id == post.CategoryToolId).ToolName;
                var postDetailsResult = new PostDetailsResult(post)
                {
                    CreationDate = post.CreationDate,
                    Description = post.Description,
                    TagsList = tagsList
                    //CategoryTypeName = categoryTypeName,
                    //CategoryToolName = categoryToolName
                        
                };

                return postDetailsResult;
            }
        }

        public List<PostsResults> GetFollowingPosts(int userId)
        {
            List<PostsResults> imagesResult = new List<PostsResults>();
            using (var db = paintStoreContext)
            {
                //IQueryable<Posts> images = null;
                var images = db.Posts.
                    Where(x => db.UserFollowers.
                        Where(y => y.FollowingUserId == userId).
                        Select(z => z.FollowedUserId).Contains(x.UserId)).
                    OrderByDescending(x => x.CreationDate);
                foreach (var image in images)
                {
                    var userOwnerImgLink = db.Users.First(x => x.Id == image.UserId).AvatarImgLink;
                    imagesResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
                }
                
            }
            return imagesResult;
        }

        public List<PostsResults> GetAllPosts(string message)
        {
            List<PostsResults> imagesResult = new List<PostsResults>();
            using (var db = paintStoreContext)
            {
                IQueryable<IPosts> images = null;
                if (message == "most_popular")
                {
                    images = db.Posts.OrderByDescending(y => (db.PostComments.Count(x => x.PostId == y.Id)));
                }
                if (message == "the_newest")
                {
                    images = db.Posts.OrderByDescending(x => x.CreationDate);
                }
                foreach (var image in images)
                {
                    var userOwnerImgLink = db.Users.First(x => x.Id == image.UserId).AvatarImgLink;
                    imagesResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
                }
                
            }
            return imagesResult;
        }

        public List<PostsResults> GetPostsByTag(string tag)
        {
            List<PostsResults> imagesResult = new List<PostsResults>();
            using (var db = paintStoreContext)
            {
                var tagId = db.Tags.First(x => x.TagName == tag).Id;
                var postsIds = db.PostTags.Where(x => x.TagId == tagId).Select(y => y.PostId).ToList();
                IQueryable<Posts> images = null;
                //var query = 
                //    context.Posts.Where(post =>
                //        post.Tags.All(tag => 
                //            tagIds.Contains(tag.TagId)));

                images = db.Posts.Where(post =>
                    postsIds.Contains(post.Id));
                    

                //images = db.Posts.Where(
                //    x => x.Id == db.PostTags.
                //             Where(y => y.TagId == postTagId));
                foreach (var image in images)
                {
                    var userOwnerImgLink = db.Users.First(x => x.Id == image.UserId).AvatarImgLink;
                    imagesResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
                }
            }

            return imagesResult;
        }

        public Posts AddImage(Posts post)
        {
            using(var db = paintStoreContext)
            {
                UsersManager.UserPostsCountPlus(db, post.UserId);
                //TODO TAGI
                //if(post.CategoryToolId != null)
                //{
                //    CategoryManager.CategoryToolCountPlus(db, post.CategoryToolId);
                //}
                //if (post.CategoryTypeId != null)
                //{
                //    CategoryManager.CategoryTypesCountPlus(db, post.CategoryTypeId);
                //}

                db.Posts.Add(post);
                var count = db.SaveChanges();            }
            return post;
        }

        public Posts EditPost(Posts post)
        {
            using (var db = paintStoreContext)
            {
                var postToUptade = db.Posts.Where(x => x.Id == post.Id).First();

                if (post.Title != null) postToUptade.Title = post.Title;
                if (post.Description != null) postToUptade.Description = post.Description;
                //TODO TAGI
                //if (post.CategoryTypeId != null)
                //{
                //    if (postToUptade.CategoryTypeId != null) CategoryManager.CategoryTypesCountMinus(db, postToUptade.CategoryTypeId);
                //    postToUptade.CategoryTypeId = post.CategoryTypeId;
                //    CategoryManager.CategoryTypesCountPlus(db, postToUptade.CategoryTypeId);
                //}
                //if (post.CategoryToolId != null)
                //{
                //    if (postToUptade.CategoryToolId != null) CategoryManager.CategoryToolCountMinus(db, postToUptade.CategoryToolId);
                //    postToUptade.CategoryToolId = post.CategoryToolId;
                //    CategoryManager.CategoryToolCountPlus(db, postToUptade.CategoryToolId);
                //}
                var count = db.SaveChanges();
                return postToUptade;
            }
        }

        public int PostRemover(int postId)
        {
            using (var db = paintStoreContext)
            {
                var tempPost = db.Posts.Where(
                    x => x.Id == postId).First();

                UsersManager.UserPostsCountMinus(db, tempPost.UserId);
                //TODO TAGI
                //if (tempPost.CategoryToolId != null)
                //{
                //    CategoryManager.CategoryToolCountMinus(db, tempPost.CategoryToolId);
                //}
                //if (tempPost.CategoryTypeId != null)
                //{
                //    CategoryManager.CategoryTypesCountMinus(db, tempPost.CategoryTypeId);
                //}

                db.Posts.Remove(db.Posts.
                    Where(x => x.Id == postId).First());
                foreach (var like in db.PostLikes.Where(x => x.PostId == postId))
                {
                    db.PostLikes.Remove(db.PostLikes.
                        Where(x => x.Id == like.Id).First());
                }

                foreach(var comment in db.PostComments.Where(x => x.PostId == postId))
                {
                    db.PostComments.Remove(db.PostComments.
                        Where(x => x.Id == comment.Id).First());
                    foreach (var like in db.CommentLikes.Where(x => x.CommentId == comment.Id))
                    {
                        db.CommentLikes.Remove(db.CommentLikes.
                            Where(x => x.Id == like.Id).First());
                    }
                }

                var count = db.SaveChanges();
                return postId;
            }
        }
    }
}
