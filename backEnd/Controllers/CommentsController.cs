using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using backEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private readonly IPostCommentsService _postCommentsService;

        public CommentsController(IPostCommentsService postCommentsService)
        {
            _postCommentsService = postCommentsService;
        }

        [HttpGet("{userId}/{postId}")]
        public IActionResult GetComments(int userId, int postId)
        {
            return Ok(_postCommentsService.GetComments(userId, postId));
        }

        [HttpPost("AddPostComment")]
        public IActionResult AddComment([FromBody] PostComments comment)
        {
            return Ok(_postCommentsService.AddComment(comment));
        }

        [HttpPut("EditPostComment")]
        public IActionResult EditComment([FromBody] PostComments comment)
        {
            return Ok(_postCommentsService.EditComment(comment));
        }

        [HttpDelete("DeletePostComment/{commentId}")]
        public IActionResult CommentRemove(int commentId)
        {
            return Ok(_postCommentsService.CommentRemove(commentId));
        }

    }
}