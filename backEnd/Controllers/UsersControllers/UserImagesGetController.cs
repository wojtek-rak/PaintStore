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
    public class UserImagesGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public UserImagesGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<Images> GetImages([FromBody] Users user)
        {
            using (var db = paintStoreContext)
            {
                var images = db.Images.Where(b => b.OwnerPath == user.Link);
                return images.ToList();
            }

        }
    }
}