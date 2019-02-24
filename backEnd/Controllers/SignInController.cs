using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.InputModels;
using SignInResult = PaintStore.Domain.ResultsModels.SignInResult;

namespace PaintStore.BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/SignIn")]
    public class SignInController : Controller
    {
        private readonly ISignInService _signInService;

        public SignInController(ISignInService signInService)
        {
            _signInService = signInService; 
        }

        [HttpPost("In")]
        public IActionResult SignIn([FromBody] SignInCommand signInCommand)
        {
            return Ok(_signInService.SignIn(signInCommand));
        }

        [HttpPost("Out")]
        public IActionResult SignOut([FromBody] SignOutCommand signOutCommand)
        {
            return Ok(_signInService.SignOut(signOutCommand));
        }
    }
}