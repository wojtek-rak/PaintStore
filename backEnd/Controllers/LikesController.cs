using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Likes")]
    public class LikesController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public LikesController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpGet("Post/{postId}")]
        public IActionResult GetPostLikes(int postId)
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
                return Ok(postLikesList);
            }
        }

        [HttpPost("Post/AddLike")]
        public IActionResult AddImageLike([FromBody] PostLikes like)
        {
            ImagesManager.ImageLikesCountPlus(paintStoreContext, like.PostId);
            paintStoreContext.PostLikes.Add(like);
            var count = paintStoreContext.SaveChanges();
            return Ok(like);
        }

        [HttpDelete("Post/RemoveLike/{likeId}")]
        public IActionResult RemoveImageLike(int likeId)
        {
            ImagesManager.ImageLikesCountMinus(paintStoreContext, paintStoreContext.PostLikes.
                Where(x => x.Id == likeId).First().PostId);
            paintStoreContext.PostLikes.Remove(paintStoreContext.PostLikes.
                Where(x => x.Id == likeId).First());
            var count = paintStoreContext.SaveChanges();
            return Ok(likeId);
        }



        [HttpGet("Comment/{commentId}")]
        public IActionResult GetCommentLikes(int commentId)
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
                return Ok(commentLikesList);
            }

            
        }

        [HttpPost("Comment/AddLike")]
        public IActionResult AddCommentLike([FromBody] CommentLikes like)
        {
            CommentsManager.CommentLikesCountPlus(paintStoreContext, like.CommentId);
            paintStoreContext.CommentLikes.Add(like);
            var count = paintStoreContext.SaveChanges();
            return Ok(like);
        }

        [HttpDelete("Comment/RemoveLike/{likeId}")]
        public IActionResult RemoveCommentLike(int likeId)
        {
            CommentsManager.CommentLikesCountMinus(paintStoreContext, paintStoreContext.CommentLikes.
                Where(x => x.Id == likeId).First().CommentId);
            paintStoreContext.CommentLikes.Remove(paintStoreContext.CommentLikes.
                Where(x => x.Id == likeId).First());
            var count = paintStoreContext.SaveChanges();
            return Ok(likeId);
        }


    }
}