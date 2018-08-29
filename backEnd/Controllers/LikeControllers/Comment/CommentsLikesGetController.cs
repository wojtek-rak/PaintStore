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
    public class CommentsLikesGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentsLikesGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<CommentLikes> GetCommentLikes([FromBody] PostComments comment)
        {
            using (var db = paintStoreContext)
            {
                var likes = db.CommentLikes.Where(b => b.CommentId == comment.Id);
                return likes.ToList();
            }

        }
    }
}