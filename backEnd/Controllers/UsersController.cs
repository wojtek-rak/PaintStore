using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public UsersController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

         [HttpGet("{userId}")]
         public IActionResult GetUser(int userId)
         {
             List<UsersResult> usersResult = new List<UsersResult>();
             using (var db = paintStoreContext)
             {
                 var userToGet = db.Users.First(b => b.Id == userId);
                
                 //userToGet.MostUsedCategoryToolName = db.Posts.Where(x => x.UserId == user.Id).GroupBy(x => x.CategoryToolId);

                 var toolId = db.Posts.Where(x => x.UserId == userId)
                     .Where(x => x.CategoryToolId != null)
                     .GroupBy(post => post.CategoryToolId)
                     .Select(group => new
                     {
                         ToolId = group.Key,
                         Count =  group.Count()
                     })
                     .OrderByDescending(y => y.Count)
                     .First().ToolId;
                 if (toolId != null)
                 {
                     usersResult.Add(new UsersResult(userToGet)
                     {
                         MostUsedCategoryToolName = db.CategoryTools.First(x => x.Id == toolId).ToolName
                     });
                 }
                 else usersResult.Add(new UsersResult(userToGet));
                 return Ok(usersResult);
             }

         }
        [HttpGet("{userId}/GetPosts")]
        public IActionResult GetPosts(int userId)
        {
            using (var db = paintStoreContext)
            {
                var images = db.Posts.Where(b => b.UserId == userId);
                return Ok(images.ToList());
            }

        }


        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] Users user)
        {
            paintStoreContext.Users.Add(user);
            var count = paintStoreContext.SaveChanges();
            return Ok(user);
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody] Users user)
        {
            //todo better
            var userToUptade = paintStoreContext.Users.Where(x => x.Id == user.Id).First();
            if (user.About != null) userToUptade.About = user.About;
            if (user.AvatarImgLink != null) userToUptade.AvatarImgLink = user.AvatarImgLink;
            if (user.BackgroundImgLink != null) userToUptade.BackgroundImgLink = user.BackgroundImgLink;
            if (user.Name != null) userToUptade.Name = user.Name;
            if (user.Link != null) userToUptade.Link = user.Link;
            var count = paintStoreContext.SaveChanges();
            return Ok(userToUptade);
        }

    }
}