using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.LikeControllers.Comment
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImageRemoveController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageRemoveController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public Posts PostRemove([FromBody] Posts post)
        {
            var tempPost = paintStoreContext.Posts.Where(
               x => x.Id == post.Id).First();

            UsersManager.UserPostsCountMinus(paintStoreContext, tempPost.UserId);

            if (tempPost.CategoryToolId != null)
            {
                CategoryManager.CategoryToolCountMinus(paintStoreContext, tempPost.CategoryToolId);
            }
            if (tempPost.CategoryTypeId != null)
            {
                CategoryManager.CategoryTypesCountMinus(paintStoreContext, tempPost.CategoryTypeId);
            }

            paintStoreContext.Posts.Remove(paintStoreContext.Posts.
                Where(x => x.Id == post.Id).First());
            foreach (var like in paintStoreContext.PostLikes.Where(x => x.PostId == post.Id))
            {
                paintStoreContext.PostLikes.Remove(paintStoreContext.PostLikes.
                    Where(x => x.Id == like.Id).First());
            }

            foreach(var comment in paintStoreContext.PostComments.Where(x => x.PostId == post.Id))
            {
                paintStoreContext.PostComments.Remove(paintStoreContext.PostComments.
                Where(x => x.Id == comment.Id).First());
                foreach (var like in paintStoreContext.CommentLikes.Where(x => x.CommentId == comment.Id))
                {
                    paintStoreContext.CommentLikes.Remove(paintStoreContext.CommentLikes.
                        Where(x => x.Id == like.Id).First());
                }
            }

            var count = paintStoreContext.SaveChanges();
            return post;
        }
    }
}

