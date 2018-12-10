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

         [HttpGet("{userId}")]
         public IActionResult GetUser(int userId)
         {
             return Ok(_usersService.GetUser(userId));
         }
        [HttpGet("{userId}/GetPosts")]
        public IActionResult GetPosts(int userId)
        {
             return Ok(_usersService.GetPosts(userId));
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