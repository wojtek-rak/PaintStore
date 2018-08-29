using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.LikeControllers.Comment
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentLikeRemoveController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentLikeRemoveController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public CommentLikes RemoveCommentLike([FromBody] CommentLikes like)
        {
            paintStoreContext.CommentLikes.Remove(paintStoreContext.CommentLikes.
                Where(x => x.Id == like.Id).First());
            var count = paintStoreContext.SaveChanges();
            return like;
        }
    }
}