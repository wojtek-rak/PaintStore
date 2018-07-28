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
    [Route("api/[controller]")]
    public class CommentsGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentsGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IQueryable<Comments> GetComments([FromBody] string imgLink)
        {
            using (var db = paintStoreContext)
            {
                var comments = db.Comments.Where(b => b.ImgLink == imgLink);
                return comments;
            }

        }

    }
}