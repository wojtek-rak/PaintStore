using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

////////////////////////////////////////////////////////////
//                                                        //
//                        DEPRECATED                      //
//                                                        //
////////////////////////////////////////////////////////////


namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserImagesGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public UserImagesGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<Posts> GetImages([FromBody] Users user)
        {
            using (var db = paintStoreContext)
            {
                var images = db.Posts.Where(b => b.UserId == user.Id);
                return images.ToList();
            }

        }
    }
}