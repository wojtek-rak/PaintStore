using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Interfaces;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public PostsController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpGet("{postId}")]
        public IActionResult GetPost(int postId)
        {
            List<PostDetailsResult> postDetailsResult = new List<PostDetailsResult>();
            using (var db = paintStoreContext)
            {
                var posts = db.Posts.Where(b => b.Id == postId);
                foreach (var post in posts)
                {
                    var categoryTypeName = post.CategoryTypeId == null ? null : 
                        db.CategoryTypes.First(x => x.Id == post.CategoryTypeId).TypeName;
                    var categoryToolName = post.CategoryToolId == null ? null : 
                        db.CategoryTools.First(x => x.Id == post.CategoryToolId).ToolName;
                    postDetailsResult.Add(new PostDetailsResult(post)
                    {
                        CreationDate = post.CreationDate,
                        Description = post.Description,
                        CategoryTypeName = categoryTypeName,
                        CategoryToolName = categoryToolName
                        
                    });
                }
                return Ok(postDetailsResult);
            }

        }

        [HttpGet("{userId}/GetFollowingPosts")]
        public IActionResult GetFollowingPosts(int userId)
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
                return Ok(imagesResult);
            }

        }

        [HttpGet("AllPosts/{message}")]
        public IActionResult GetAllPosts(string message)
        {
            using (var db = paintStoreContext)
            {
                List<PostsResults> imagesResult = new List<PostsResults>();
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
                return Ok(imagesResult);
            }

        }

        [HttpGet("AllPosts/{message}/{name}")]
        public IActionResult GetPostsByCategory(string message, string name)
        {
            using (var db = paintStoreContext)
            {

                List<PostsResults> imagesResult = new List<PostsResults>();
                IQueryable<Posts> images = null;
                if (message == "type")
                {
                    images = db.Posts.Where(
                        x => x.CategoryTypeId == db.CategoryTypes.
                                 Where(y => y.TypeName == name).First().Id);
                }
                if (message == "tool")
                {
                    images = db.Posts.Where(
                        x => x.CategoryToolId == db.CategoryTools.
                                 Where(y => y.ToolName == name).First().Id);
                }
                if (message == "both")
                {
                    images = db.Posts.Where(
                            x => x.CategoryTypeId == db.CategoryTypes.
                                     Where(y => y.TypeName == name).First().Id).
                        Where(x => x.CategoryToolId == db.CategoryTools.
                                       Where(y => y.ToolName == name).First().Id);
                }
                foreach (var image in images)
                {
                    var userOwnerImgLink = db.Users.First(x => x.Id == image.UserId).AvatarImgLink;
                    imagesResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
                }
                return Ok(imagesResult);
            }
        }
        [HttpGet("AllPosts/{message}/{typeName}/{toolName}")]
        public IActionResult GetPostsByCategory(string message, string typeName, string toolName)
        {
            using (var db = paintStoreContext)
            {

                List<PostsResults> imagesResult = new List<PostsResults>();
                IQueryable<Posts> images = null;
                if (message == "both")
                {
                    images = db.Posts.Where(
                            x => x.CategoryTypeId == db.CategoryTypes.
                                     Where(y => y.TypeName == typeName).First().Id).
                        Where(x => x.CategoryToolId == db.CategoryTools.
                                       Where(y => y.ToolName == toolName).First().Id);
                }
                foreach (var image in images)
                {
                    var userOwnerImgLink = db.Users.First(x => x.Id == image.UserId).AvatarImgLink;
                    imagesResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
                }
                return Ok(imagesResult);
            }
        }

        [HttpPost("AddPost")]
        public IActionResult AddImage([FromBody] Posts post)
        {
            using(var db = paintStoreContext)
            {
                UsersManager.UserPostsCountPlus(db, post.UserId);
                if(post.CategoryToolId != null)
                {
                    CategoryManager.CategoryToolCountPlus(db, post.CategoryToolId);
                }
                if (post.CategoryTypeId != null)
                {
                    CategoryManager.CategoryTypesCountPlus(db, post.CategoryTypeId);
                }

                db.Posts.Add(post);
                var count = db.SaveChanges();
                return Ok(post);
            }
        }
        [HttpPut("EditPost")]
        public IActionResult EditPost([FromBody] Posts post)
        {
            var postToUptade = paintStoreContext.Posts.Where(x => x.Id == post.Id).First();

            if (post.Title != null) postToUptade.Title = post.Title;
            if (post.Description != null) postToUptade.Description = post.Description;
            if (post.CategoryTypeId != null)
            {
                if (postToUptade.CategoryTypeId != null) CategoryManager.CategoryTypesCountMinus(paintStoreContext, postToUptade.CategoryTypeId);
                postToUptade.CategoryTypeId = post.CategoryTypeId;
                CategoryManager.CategoryTypesCountPlus(paintStoreContext, postToUptade.CategoryTypeId);
            }
            if (post.CategoryToolId != null)
            {
                if (postToUptade.CategoryToolId != null) CategoryManager.CategoryToolCountMinus(paintStoreContext, postToUptade.CategoryToolId);
                postToUptade.CategoryToolId = post.CategoryToolId;
                CategoryManager.CategoryToolCountPlus(paintStoreContext, postToUptade.CategoryToolId);
            }
            var count = paintStoreContext.SaveChanges();
            return Ok(postToUptade);
        }

        [HttpDelete("DeletePost/{postId}")]
        public IActionResult PostRemove(int postId)
        {
            return Ok(PostRemover(paintStoreContext, postId));
        }

        public static int PostRemover(PaintStoreContext db, int postId)
        {
            var tempPost = db.Posts.Where(
                x => x.Id == postId).First();

            UsersManager.UserPostsCountMinus(db, tempPost.UserId);

            if (tempPost.CategoryToolId != null)
            {
                CategoryManager.CategoryToolCountMinus(db, tempPost.CategoryToolId);
            }
            if (tempPost.CategoryTypeId != null)
            {
                CategoryManager.CategoryTypesCountMinus(db, tempPost.CategoryTypeId);
            }

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