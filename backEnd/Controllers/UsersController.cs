using System;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.Entities;
using PaintStore.Domain.InputModels;

namespace PaintStore.BackEnd.Controllers
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
        /// <param name="userId"></param>
        /// <param name="message">"the_newest" for newest
        /// "most_popular" for most popular
        /// </param>
        [HttpGet("{userId}/GetPosts/{message}")]
        public IActionResult GetPosts(int userId, string message)
        {
             return Ok(_usersService.GetPosts(userId, message));
        }


        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] AddUserCommand user)
        {
            return Ok(_usersService.AddUser(user));
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody] EditUserCommand user)
        {
            return Ok(_usersService.EditUser(user));
        }

        [HttpPut("EditUserCredentials")]
        public IActionResult EditUserCredentials([FromBody] EditUserCredentialsCommand user)
        {
            return Ok(_usersService.EditUserCredentials(user));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult RemoveUser([FromBody] RemoveUserCommand user)
        {
            try
            {
                var userRemoved = _usersService.RemoveUser(user);
                return Ok(userRemoved);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(401);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}