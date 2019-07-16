using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.Entities;
using PaintStore.Domain.Exceptions;
using PaintStore.Domain.InputModels;

namespace PaintStore.BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Followers")]
    public class FollowersController : Controller
    {
        private readonly IFollowersService _followersService;
        readonly ILogger<FollowersController> _logger;

        public FollowersController(ILogger<FollowersController> logger, IFollowersService followersService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
        public IActionResult AddFollower([FromBody] AddUserFollowersCommand follow)
        {
            try
            {
                return Ok(_followersService.AddFollower(follow));
            }
            catch (NegotiatedContentResultException)
            {
                _logger.LogError($"Cannot Add Follower by {follow.FollowingUserId} to {follow.FollowedUserId}");
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