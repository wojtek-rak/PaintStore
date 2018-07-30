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
        public IEnumerable<Images> GetImagesByCategory([FromBody] Message message)
        {
            using (var db = paintStoreContext)
            {
                IQueryable<Images> images = null;
                if (message.Properties == "type")
                {
                    images = db.Images.Where(x => x.Category_type == message.Category_type);
                }
                if (message.Properties == "tool")
                {
                    images = db.Images.Where(x => x.Category_tool == message.Category_tool);
                }
                if (message.Properties == "both")
                {
                    images = db.Images.Where(x => x.Category_type == message.Category_type).Where(x => x.Category_tool == message.Category_tool);
                }
                return images.ToList();
            }

        }
    }
}