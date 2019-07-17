﻿using Microsoft.AspNetCore.Mvc;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.Entities;
using PaintStore.Domain.Exceptions;

namespace PaintStore.BackEnd.Controllers
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
        [HttpGet("Post/{loggedUserId}/{postId}")]
        public IActionResult GetPostLikes(int loggedUserId, int postId)
        {
            return Ok(_likesService.GetPostLikes(loggedUserId, postId));
        }

        /// <response code="409">If there is already that like</response>     
        [HttpPost("Post/AddLike")]
        public IActionResult AddImageLike([FromBody] PostLikes like)
        {
            try
            {
                return Ok(_likesService.AddImageLike(like));
            }
            catch (NegotiatedContentResultException)
            {
                return StatusCode(409);
            }
        }

        [HttpDelete("Post/RemoveLike/{userId}/{postId}")]
        public IActionResult RemoveImageLike(int userId, int postId)
        {
            return Ok(_likesService.RemoveImageLike(userId, postId));
        }



        [HttpGet("Comment/{loggedUserId}/{commentId}")]
        public IActionResult GetCommentLikes(int loggedUserId, int commentId)
        {
            return Ok(_likesService.GetCommentLikes(loggedUserId, commentId));
        }

        /// <response code="409">If there is already that like</response>     
        [HttpPost("Comment/AddLike")]
        public IActionResult AddCommentLike([FromBody] CommentLikes like)
        {
            try
            {
                return Ok(_likesService.AddCommentLike(like));
            }
            catch (NegotiatedContentResultException)
            {
                return StatusCode(409);
            }
        }

        [HttpDelete("Comment/RemoveLike/{userId}/{commentId}")]
        public IActionResult RemoveCommentLike(int userId, int commentId)
        {
            return Ok(_likesService.RemoveCommentLike(userId, commentId));
        }


    }
}