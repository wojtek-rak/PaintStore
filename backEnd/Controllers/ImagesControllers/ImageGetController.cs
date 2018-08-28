using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    public class ImageGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<Posts> GetImage([FromBody] Posts image)
        {
            using (var db = paintStoreContext)
            {
                var images = db.Posts.Where(b => b.ImgLink == image.ImgLink);
                return images.ToList();
            }

        }
    }
}