using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.LikeControllers.Comment;
using backEnd.Models;
using backEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpPost("AddAccount")]
        public IActionResult AddAccount([FromBody] Accounts account)
        {
            return Ok(_accountsService.AddAccount(account));
        }

        [HttpPut("EditAccount")]
        public IActionResult EditAccount([FromBody] Accounts account)
        {
            return Ok(_accountsService.EditAccount(account));
        }

        [HttpPost("DeleteAccount")]
        public IActionResult RemoveAccount([FromBody] Accounts account)
        {
            return Ok(account);
        }
    }
}