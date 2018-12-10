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
    [Route("api/Likes")]
    public class LikesController : Controller
    {
        private readonly ILikesService _likesService;
        public LikesController(ILikesService likesService)
        {
            _likesService = likesService;
        }
        [HttpGet("Post/{postId}")]
        public IActionResult GetPostLikes(int postId)
        {
            return Ok(_likesService.GetPostLikes(postId));
        }

        [HttpPost("Post/AddLike")]
        public IActionResult AddImageLike([FromBody] PostLikes like)
        {
            return Ok(_likesService.AddImageLike(like));
        }

        [HttpDelete("Post/RemoveLike/{likeId}")]
        public IActionResult RemoveImageLike(int likeId)
        {
            return Ok(_likesService.RemoveImageLike(likeId));
        }



        [HttpGet("Comment/{commentId}")]
        public IActionResult GetCommentLikes(int commentId)
        {
            return Ok(_likesService.GetCommentLikes(commentId));
        }

        [HttpPost("Comment/AddLike")]
        public IActionResult AddCommentLike([FromBody] CommentLikes like)
        {
            return Ok(_likesService.AddCommentLike(like));
        }

        [HttpDelete("Comment/RemoveLike/{likeId}")]
        public IActionResult RemoveCommentLike(int likeId)
        {
            return Ok(_likesService.RemoveCommentLike(likeId));
        }


    }
}