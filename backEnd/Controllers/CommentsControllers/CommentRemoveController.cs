using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.LikeControllers.Comment
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentRemoveController : Controller
    {

        private readonly PaintStoreContext paintStoreContext;

        public CommentRemoveController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public PostComments CommentRemove([FromBody] PostComments comment)
        {
            ImagesManager.ImageCommentCountMinus(paintStoreContext, paintStoreContext.PostComments.
                Where(x => x.Id == comment.Id).First().PostId);
            paintStoreContext.PostComments.Remove(paintStoreContext.PostComments.
                Where(x => x.Id == comment.Id).First());
            foreach(var like in paintStoreContext.CommentLikes.Where(x => x.CommentId == comment.Id))
            {
                paintStoreContext.CommentLikes.Remove(paintStoreContext.CommentLikes.
                    Where(x => x.Id == like.Id).First());
            }
            var count = paintStoreContext.SaveChanges();
            return comment;
        }
    }
}
