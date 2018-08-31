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
    public class ImagesFollowingGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImagesFollowingGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<Posts> GetImages([FromBody] Users user)
        {
            using (var db = paintStoreContext)
            {
                //IQueryable<Posts> images = null;
                var images = db.Posts.
                    Where(x => db.UserFollowers.
                    Where(y => y.FollowingUserId == user.Id).
                    Select(z => z.FollowedUserId).Contains(x.UserId)).
                    OrderByDescending(x => x.CreationDate);
                return images.ToList();
            }

        }
    }
}

