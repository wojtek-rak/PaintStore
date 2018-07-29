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
        public IQueryable<Images> GetImagesByCategory([FromBody] string message, string category_type, string category_tool)
        {
            using (var db = paintStoreContext)
            {
                IQueryable<Images> images = null;
                if (message == "type")
                {
                    images = db.Images.Where(x => x.Category_type == category_type);
                }
                if (message == "tool")
                {
                    images = db.Images.Where(x => x.Category_tool == category_tool);
                }
                if (message == "both")
                {
                    images = db.Images.Where(x => x.Category_type == category_type).Where(x => x.Category_tool == category_tool);
                }
                return images;
            }

        }
    }
}