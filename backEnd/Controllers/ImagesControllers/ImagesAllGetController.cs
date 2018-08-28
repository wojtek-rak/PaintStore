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
        public IEnumerable<Posts> GetAllImages([FromBody] Message message)
        {
            using (var db = paintStoreContext)
            {
                IQueryable<Posts> images = null;
                if (message.Properties == "most_popular")
                {
                    
                    images = db.Posts.OrderByDescending(y => (db.PostComments.Where(x => x.PostId == y.Id).Count()));
                }
                if (message.Properties == "the_newest")
                {
                     images = db.Posts.OrderByDescending(x => x.CreationDate);
                }
                return images.ToList();
            }

        }
    }
}