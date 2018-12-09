using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

////////////////////////////////////////////////////////////
//                                                        //
//                        DEPRECATED                      //
//                                                        //
////////////////////////////////////////////////////////////


namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
            return PostRemover(paintStoreContext, post);
        }

        public static Posts PostRemover(PaintStoreContext db, Posts post)
        {
            var tempPost = db.Posts.Where(
                x => x.Id == post.Id).First();

            UsersManager.UserPostsCountMinus(db, tempPost.UserId);

            if (tempPost.CategoryToolId != null)
            {
                CategoryManager.CategoryToolCountMinus(db, tempPost.CategoryToolId);
            }
            if (tempPost.CategoryTypeId != null)
            {
                CategoryManager.CategoryTypesCountMinus(db, tempPost.CategoryTypeId);
            }

            db.Posts.Remove(db.Posts.
                Where(x => x.Id == post.Id).First());
            foreach (var like in db.PostLikes.Where(x => x.PostId == post.Id))
            {
                db.PostLikes.Remove(db.PostLikes.
                    Where(x => x.Id == like.Id).First());
            }

            foreach (var comment in db.PostComments.Where(x => x.PostId == post.Id))
            {
                db.PostComments.Remove(db.PostComments.
                    Where(x => x.Id == comment.Id).First());
                foreach (var like in db.CommentLikes.Where(x => x.CommentId == comment.Id))
                {
                    db.CommentLikes.Remove(db.CommentLikes.
                        Where(x => x.Id == like.Id).First());
                }
            }

            var count = db.SaveChanges();
            return post;
        }
    }
}

