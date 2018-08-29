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
    public class ImageLikesGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageLikesGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<PostLikes> GetImageLikes([FromBody] Posts image)
        {
            using (var db = paintStoreContext)
            {
                var likes = db.PostLikes.Where(b => b.PostId == image.Id);
                return likes.ToList();
            }

        }
    }
}