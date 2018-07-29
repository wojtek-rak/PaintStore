using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.CommentsControllers
{
    [Route("api/[controller]")]
    public class ImageAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpPost]
        public Images AddImage([FromBody] Images image)
        {
            paintStoreContext.Images.Add(image);
            var count = paintStoreContext.SaveChanges();
            return image;
        }
    }
}