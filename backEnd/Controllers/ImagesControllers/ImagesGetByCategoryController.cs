using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.ImagesControllers
{
    [Route("api/[controller]")]
    public class ImagesGetByCategoryController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImagesGetByCategoryController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<Posts> GetImagesByCategory([FromBody] Message message)
        {
            using (var db = paintStoreContext)
            {

                ///
                /// NOT WORKING CHANGE FROM DESCRIPTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                ///

                IQueryable<Posts> images = null;
                if (message.Properties == "type")
                {
                    images = db.Posts.Where(x => x.Description == message.Category_type);
                }
                if (message.Properties == "tool")
                {
                    images = db.Posts.Where(x => x.Description == message.Category_type);
                }
                if (message.Properties == "both")
                {
                    images = db.Posts.Where(x => x.Description == message.Category_type).Where(x => x.Description == message.Category_tool);
                }
                return images.ToList();
            }

        }
    }
}