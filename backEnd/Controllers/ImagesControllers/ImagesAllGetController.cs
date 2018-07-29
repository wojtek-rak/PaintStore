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
    public class ImagesAllGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImagesAllGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IQueryable<Images> GetAllImages([FromBody] string message)
        {
            using (var db = paintStoreContext)
            {
                IQueryable<Images> images = null;
                if (message == "most_popular")
                {
                    
                    images = db.Images.OrderByDescending(y => (db.Comments.Where(x => x.ImgLink == y.ImgLink).Count()));
                }
                if (message == "the_newest")
                {
                     images = db.Images.OrderByDescending(x => x.Date);
                }
                return images;
            }

        }
    }
}