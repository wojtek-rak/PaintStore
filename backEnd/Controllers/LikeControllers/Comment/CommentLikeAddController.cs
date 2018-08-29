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
    public class CommentLikeAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentLikeAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public CommentLikes AddCommentLike([FromBody] CommentLikes like)
        {
            paintStoreContext.CommentLikes.Add(like);
            var count = paintStoreContext.SaveChanges();
            return like;
        }
    }
}