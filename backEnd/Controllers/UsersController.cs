using System;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.Entities;
using PaintStore.Domain.InputModels;
using PaintStore.Domain.Exceptions;

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

        [HttpPost("GetUserEmail")]
        public IActionResult GetUserEmail([FromBody] GetUserEmailCommand user)
        {
            return Ok(_usersService.GetUserEmail(user));
        }

        /// <response code="403">If there is already that Name</response>   
        /// <response code="409">If there is already that Email</response>   
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] AddUserCommand user)
        {
            try
            {
                return Ok(_usersService.AddUser(user));
            }
            catch (DuplicateEmailException)
            {
                return StatusCode(409);
            }
            catch (DuplicateNameException)
            {
                return StatusCode(403);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody] EditUserCommand user)
        {
            return Ok(_usersService.EditUser(user));
        }

        [HttpPut("EditUserCredentials")]
        public IActionResult EditUserCredentials([FromBody] EditUserCredentialsCommand user)
        {
            try
            {
                var editCredentials = _usersService.EditUserCredentials(user);
                return Ok(editCredentials.Email);
            }
            catch (BadPasswordException)
            {
                return StatusCode(409);
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