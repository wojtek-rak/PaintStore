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


namespace backEnd.Controllers.LikeControllers.Comment
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
            //var tempFollow = paintStoreContext.UserFollowers.Where(x => x.Id == follow.Id).First();
            //FollowersManager.UserFollowedCountMinus(paintStoreContext, tempFollow.FollowedUserId);
            //FollowersManager.UserFollowingCountMinus(paintStoreContext, tempFollow.FollowingUserId);
            //paintStoreContext.UserFollowers.Remove(paintStoreContext.UserFollowers.
            //    Where(x => x.Id == follow.Id).First());
            //var count = paintStoreContext.SaveChanges();
            return FollowRemover(paintStoreContext, follow);
        }

        public static UserFollowers FollowRemover(PaintStoreContext db, UserFollowers follow)
        {
            var tempFollow = db.UserFollowers.First(x => x.Id == follow.Id);
            FollowersManager.UserFollowedCountMinus(db, tempFollow.FollowedUserId);
            FollowersManager.UserFollowingCountMinus(db, tempFollow.FollowingUserId);
            db.UserFollowers.Remove(db.UserFollowers.First(x => x.Id == follow.Id));
            var count = db.SaveChanges();
            return follow;
        }
    }
}

