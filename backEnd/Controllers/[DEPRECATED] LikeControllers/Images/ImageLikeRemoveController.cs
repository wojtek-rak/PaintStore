using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

////////////////////////////////////////////////////////////
//                                                        //
//                        DEPRECATED                      //
//                                                        //
////////////////////////////////////////////////////////////


namespace backEnd.Controllers.LikeControllers.Comment
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ImageLikeRemoveController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageLikeRemoveController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public PostLikes RemoveImageLike([FromBody] PostLikes like)
        {
            ImagesManager.ImageLikesCountMinus(paintStoreContext, paintStoreContext.PostLikes.
                Where(x => x.Id == like.Id).First().PostId);
            paintStoreContext.PostLikes.Remove(paintStoreContext.PostLikes.
                Where(x => x.Id == like.Id).First());
            var count = paintStoreContext.SaveChanges();
            return like;
        }
    }
}

