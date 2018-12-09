using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.FollowersControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

////////////////////////////////////////////////////////////
//                                                        //
//                        DEPRECATED                      //
//                                                        //
////////////////////////////////////////////////////////////


namespace backEnd.Controllers.CommentsControllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class FollowersAddController : Controller
    {

        private readonly PaintStoreContext paintStoreContext;

        public FollowersAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpPost]
        public UserFollowers AddFollower([FromBody] UserFollowers follow)
        {
            FollowersManager.UserFollowedCountPlus(paintStoreContext, follow.FollowedUserId);
            FollowersManager.UserFollowingCountPlus(paintStoreContext, follow.FollowingUserId);
            paintStoreContext.UserFollowers.Add(follow);
            var count = paintStoreContext.SaveChanges();
            return follow;
        }
    }
}
