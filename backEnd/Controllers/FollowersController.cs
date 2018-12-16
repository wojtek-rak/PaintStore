using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using backEnd.Controllers.FollowersControllers;
using backEnd.Exceptions;
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