using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.LikeControllers.Images
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImageLikeAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageLikeAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public PostLikes AddImageLike([FromBody] PostLikes like)
        {
            paintStoreContext.PostLikes.Add(like);
            var count = paintStoreContext.SaveChanges();
            return like;
        }
    }
}