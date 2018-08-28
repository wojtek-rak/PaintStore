using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    /// <summary>
    ///  Use /api/CommentsGet to get comments with POST string
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentsGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentsGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<PostComments> GetComments([FromBody] Posts post)//([FromBody] string imgLink)
        {
            using (var db = paintStoreContext)
            {
                var comments = db.PostComments.Where(b => b.PostId == post.Id);
                return comments.ToList();
            }

        }

    }
}