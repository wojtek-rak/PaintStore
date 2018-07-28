using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/ImageGet")]
    public class ImageGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IQueryable<Images> GetImage([FromBody] string imgLink)
        {
            using (var db = paintStoreContext)
            {
                var images = db.Images.Where(b => b.ImgLink == imgLink);
                return images;
            }

        }
    }
}