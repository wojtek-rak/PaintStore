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
    public class FollowingGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public FollowingGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<LikesResult> GetFollowingUser([FromBody] Users user)
        {
            using (var db = paintStoreContext)
            {
                var followsList = new List<LikesResult>();
                var follows = db.UserFollowers.Where(b => b.FollowingUserId == user.Id)
                    .OrderByDescending(followed => db.Users.First(userF => userF.Id == followed.FollowedUserId).FollowedCount);
                foreach (var follow in follows)
                {
                    var userTemp = db.Users.First(x => x.Id == follow.FollowedUserId);
                    followsList.Add(new LikesResult(follow.FollowedUserId, userTemp.Name, userTemp.AvatarImgLink));
                }
                return followsList;
            }
        }  
    }
}



