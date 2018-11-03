using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



////////////////////////////////////////////////////////////
//                                                        //
//                        DEPRECATED                      //
//                                                        //
////////////////////////////////////////////////////////////



namespace backEnd.Controllers.CommentsControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentEditController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentEditController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public PostComments EditComment([FromBody] PostComments comment)
        {
            var commentToUptade = paintStoreContext.PostComments.Where(x => x.Id == comment.Id).First();
            commentToUptade.Content = comment.Content;
            var count = paintStoreContext.SaveChanges();
            return commentToUptade;
        }
    }
}