using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Interfaces;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using backEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet("{userId}/{postId}")]
        public IActionResult GetPost(int userId, int postId)
        {
            return Ok(_postsService.GetPost(userId, postId));
        }

        [HttpGet("{userId}/GetFollowingPosts")]
        public IActionResult GetFollowingPosts(int userId)
        {
            return Ok(_postsService.GetFollowingPosts(userId));

        }

        [HttpGet("AllPosts/{message}")]
        public IActionResult GetAllPosts(string message)
        {
            return Ok(GetAllPosts(message));
        }

        [HttpGet("AllPostsByTag/{tag}")]
        public IActionResult GetPostsByTag(string tag)
        {
            return Ok(_postsService.GetPostsByTag(tag));
        }


        [HttpPost("AddPost")]
        public IActionResult AddImage([FromBody] Posts post)
        {
            return Ok(_postsService.AddImage(post));
        }
        [HttpPut("EditPost")]
        public IActionResult EditPost([FromBody] Posts post)
        {
            
            return Ok(_postsService.EditPost(post));
        }

        [HttpDelete("DeletePost/{postId}")]
        public IActionResult PostRemove(int postId)
        {
            return Ok(_postsService.PostRemover(postId));
        }
        //[HttpGet("AllPosts/{message}/{typeName}/{toolName}")]
        //public IActionResult GetPostsByCategory(string message, string typeName, string toolName)
        //{
        //    using (var db = paintStoreContext)
        //    {

        //        List<PostsResults> imagesResult = new List<PostsResults>();
        //        IQueryable<Posts> images = null;
        //        if (message == "both")
        //        {
        //            images = db.Posts.Where(
        //                    x => x.CategoryTypeId == db.CategoryTypes.
        //                             Where(y => y.TypeName == typeName).First().Id).
        //                Where(x => x.CategoryToolId == db.CategoryTools.
        //                               Where(y => y.ToolName == toolName).First().Id);
        //        }
        //        foreach (var image in images)
        //        {
        //            var userOwnerImgLink = db.Users.First(x => x.Id == image.UserId).AvatarImgLink;
        //            imagesResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
        //        }
        //        return Ok(imagesResult);
        //    }
        //}
    }
}