using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


////////////////////////////////////////////////////////////
//                                                        //
//                        DEPRECATED                      //
//                                                        //
////////////////////////////////////////////////////////////


namespace backEnd.Controllers.FollowersControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FollowedGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public FollowedGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<LikesResult> GetFollowedUser([FromBody] Users user)
        {
            using (var db = paintStoreContext)
            {
                var followsList = new List<LikesResult>();
                var follows = db.UserFollowers.Where(b => b.FollowedUserId == user.Id)
                    .OrderByDescending(following => db.Users.First(userF => userF.Id == following.FollowingUserId).FollowedCount);
                foreach (var follow in follows)
                {
                    var userTemp = db.Users.First(x => x.Id == follow.FollowingUserId);
                    followsList.Add(new LikesResult(follow.FollowingUserId, userTemp.Name, userTemp.AvatarImgLink));
                }
                return followsList;
            }
        }  
    }
}

