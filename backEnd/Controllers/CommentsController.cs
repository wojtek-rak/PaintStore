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
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentsController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpGet("{postId}")]
        public IActionResult GetComments(int postId)
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
                return Ok(commentsResult);
            }
        }

        [HttpPost("AddPostComment")]
        public IActionResult AddComment([FromBody] PostComments comment)
        {
            ImagesManager.ImageCommentCountPlus(paintStoreContext, comment.PostId);
            paintStoreContext.PostComments.Add(comment);
            var count = paintStoreContext.SaveChanges();
            return Ok(comment);
        }

        [HttpPut("EditPostComment")]
        public IActionResult EditComment([FromBody] PostComments comment)
        {
            var commentToUptade = paintStoreContext.PostComments.Where(x => x.Id == comment.Id).First();
            commentToUptade.Content = comment.Content;
            var count = paintStoreContext.SaveChanges();
            return Ok(commentToUptade);
        }

        [HttpDelete("DeletePostComment/{commentId}")]
        public IActionResult CommentRemove(int commentId)
        {
            ImagesManager.ImageCommentCountMinus(paintStoreContext, paintStoreContext.PostComments.
                Where(x => x.Id == commentId).First().PostId);
            paintStoreContext.PostComments.Remove(paintStoreContext.PostComments.
                Where(x => x.Id == commentId).First());
            foreach(var like in paintStoreContext.CommentLikes.Where(x => x.CommentId == commentId))
            {
                paintStoreContext.CommentLikes.Remove(paintStoreContext.CommentLikes.
                    Where(x => x.Id == like.Id).First());
            }
            var count = paintStoreContext.SaveChanges();
            return Ok(commentId);
        }

    }
}