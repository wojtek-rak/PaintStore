using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/UserImagesGet")]
    public class UserImagesGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public UserImagesGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IQueryable<Images> GetImages([FromBody] string ownerPath)
        {
            using (var db = paintStoreContext)
            {
                var images = db.Images.Where(b => b.OwnerPath == ownerPath);
                return images;
            }

        }
    }
}