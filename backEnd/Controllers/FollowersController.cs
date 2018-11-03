using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.FollowersControllers;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Followers")]
    public class FollowersController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public FollowersController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpGet("GetFollowed/{userId}")]
        public IActionResult GetFollowedUser(int userId)
        {
            using (var db = paintStoreContext)
            {
                var followsList = new List<LikesResult>();
                var follows = db.UserFollowers.Where(b => b.FollowedUserId == userId)
                    .OrderByDescending(following => db.Users.First(userF => userF.Id == following.FollowingUserId).FollowedCount);
                foreach (var follow in follows)
                {
                    var userTemp = db.Users.First(x => x.Id == follow.FollowingUserId);
                    followsList.Add(new LikesResult(follow.FollowingUserId, userTemp.Name, userTemp.AvatarImgLink));
                }
                return Ok(followsList);
            }
        }  

        [HttpGet("GetFollowing/{userId}")]
        public IActionResult GetFollowingUser(int userId)
        {
            using (var db = paintStoreContext)
            {
                var followsList = new List<LikesResult>();
                var follows = db.UserFollowers.Where(b => b.FollowingUserId == userId)
                    .OrderByDescending(followed => db.Users.First(userF => userF.Id == followed.FollowedUserId).FollowedCount);
                foreach (var follow in follows)
                {
                    var userTemp = db.Users.First(x => x.Id == follow.FollowedUserId);
                    followsList.Add(new LikesResult(follow.FollowedUserId, userTemp.Name, userTemp.AvatarImgLink));
                }
                return Ok(followsList);
            }
        }  

        [HttpPost("AddFollower")]
        public IActionResult AddFollower([FromBody] UserFollowers follow)
        {
            FollowersManager.UserFollowedCountPlus(paintStoreContext, follow.FollowedUserId);
            FollowersManager.UserFollowingCountPlus(paintStoreContext, follow.FollowingUserId);
            paintStoreContext.UserFollowers.Add(follow);
            var count = paintStoreContext.SaveChanges();
            return Ok(follow);
        }

        [HttpDelete("DeleteFollower/{followId}")]
        public IActionResult FollowRemove(int followId)
        {
            // To improve
            return Ok(FollowRemover(paintStoreContext, followId));
        }


        public static int FollowRemover(PaintStoreContext db, int followId)
        {
            var tempFollow = db.UserFollowers.First(x => x.Id == followId);
            FollowersManager.UserFollowedCountMinus(db, tempFollow.FollowedUserId);
            FollowersManager.UserFollowingCountMinus(db, tempFollow.FollowingUserId);
            db.UserFollowers.Remove(db.UserFollowers.First(x => x.Id == followId));
            var count = db.SaveChanges();
            return followId;
        }
    }
}