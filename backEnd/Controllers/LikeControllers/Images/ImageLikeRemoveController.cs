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
            paintStoreContext.PostLikes.Remove(paintStoreContext.PostLikes.
                Where(x => x.Id == like.Id).First());
            var count = paintStoreContext.SaveChanges();
            return like;
        }
    }
}

