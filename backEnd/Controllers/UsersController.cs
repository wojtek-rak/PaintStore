using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using backEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

         [HttpGet("{loggedUserId}/{userId}")]
         public IActionResult GetUser(int loggedUserId, int userId)
         {
             return Ok(_usersService.GetUser(loggedUserId, userId));
         }

        /// <summary>
        /// Get AllPosts of specific user
        /// </summary>
        /// <param name="message">"the_newest" for newest
        /// "most_popular" for most popular
        /// </param>
        [HttpGet("{userId}/GetPosts/{message}")]
        public IActionResult GetPosts(int userId, string message)
        {
             return Ok(_usersService.GetPosts(userId, message));
        }


        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] Users user)
        {
            return Ok(_usersService.AddUser(user));
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody] Users user)
        {
            return Ok(_usersService.EditUser(user));
        }

    }
}