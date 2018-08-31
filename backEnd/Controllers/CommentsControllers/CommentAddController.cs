using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.CommentsControllers
{
    [Route("api/[controller]")]
    public class CommentAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpPost]
        public PostComments AddComment([FromBody] PostComments comment)
        {
            ImagesManager.ImageCommentCountPlus(paintStoreContext, comment.PostId);
            paintStoreContext.PostComments.Add(comment);
            var count = paintStoreContext.SaveChanges();
            return comment;
        }
    }
}