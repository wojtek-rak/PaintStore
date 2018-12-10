using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.FollowersControllers;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using backEnd.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetFollowed/{userId}")]
        public IActionResult GetFollowedUser(int userId)
        {
            return Ok(_followersService.GetFollowedUser(userId));

        }  

        [HttpGet("GetFollowing/{userId}")]
        public IActionResult GetFollowingUser(int userId)
        {
            return Ok(_followersService.GetFollowingUser(userId));
        }  

        [HttpPost("AddFollower")]
        public IActionResult AddFollower([FromBody] UserFollowers follow)
        {
            return Ok(_followersService.AddFollower(follow));
        }

        [HttpDelete("DeleteFollower/{followId}")]
        public IActionResult FollowRemove(int followId)
        {
            return Ok(_followersService.FollowRemove(followId));
        }

    }
}