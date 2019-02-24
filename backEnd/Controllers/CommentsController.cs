using Microsoft.AspNetCore.Mvc;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.Entities;

namespace PaintStore.BackEnd.Controllers
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