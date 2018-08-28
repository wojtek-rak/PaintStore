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
        public Posts AddImage([FromBody] Posts post)
        {
            paintStoreContext.Posts.Add(post);
            var count = paintStoreContext.SaveChanges();
            return post;
        }
    }
}