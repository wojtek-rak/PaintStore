using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.FollowersControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.LikeControllers.Comment
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FollowersRemoveController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public FollowersRemoveController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public UserFollowers FollowRemove([FromBody] UserFollowers follow)
        {
            var tempFollow = paintStoreContext.UserFollowers.Where(x => x.Id == follow.Id).First();
            FollowersManager.UserFollowedCountMinus(paintStoreContext, tempFollow.FollowedUserId);
            FollowersManager.UserFollowingCountMinus(paintStoreContext, tempFollow.FollowingUserId);
            paintStoreContext.UserFollowers.Remove(paintStoreContext.UserFollowers.
                Where(x => x.Id == follow.Id).First());
            var count = paintStoreContext.SaveChanges();
            return follow;
        }
    }
}

