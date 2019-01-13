using backEnd.Exceptions;
using backEnd.Models;
using backEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Followers")]
    public class FollowersController : Controller
    {
        private readonly IFollowersService _followersService;

        public FollowersController(IFollowersService followersService)
        {
            _followersService = followersService;
        }

        [HttpGet("GetFollowed/{loggedUserId}/{userId}")]
        public IActionResult GetFollowedUser(int loggedUserId, int userId)
        {
            return Ok(_followersService.GetFollowedUser(loggedUserId, userId));

        }  

        [HttpGet("GetFollowing/{loggedUserId}/{userId}")]
        public IActionResult GetFollowingUser(int loggedUserId, int userId)
        {
            return Ok(_followersService.GetFollowingUser(loggedUserId, userId));
        }  
        /// <summary>
        /// Add follower
        /// </summary>
        /// <param name="follow"></param>
        /// <response code="409">If there is already such an object in the database, or when followedId == followingId</response>         
        [HttpPost("AddFollower")]
        public IActionResult AddFollower([FromBody] UserFollowers follow)
        {
            try
            {
                return Ok(_followersService.AddFollower(follow));
            }
            catch (NegotiatedContentResultExeption e)
            {
                return StatusCode(409);
            }
        }

        [HttpDelete("DeleteFollower/{userIdFollowing}/{userIdFollowed}")]
        public IActionResult FollowRemove(int userIdFollowing, int userIdFollowed)
        {
            return Ok(_followersService.FollowRemove(userIdFollowing, userIdFollowed));
        }

    }
}