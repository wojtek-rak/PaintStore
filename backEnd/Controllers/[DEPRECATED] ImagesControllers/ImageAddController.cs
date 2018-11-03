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


namespace backEnd.Controllers.CommentsControllers
{
    [Route("api/[controller]")]
    public class ImageAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpPost]
        public Posts AddImage([FromBody] Posts post)
        {
            using(var db = paintStoreContext)
            {
                UsersManager.UserPostsCountPlus(db, post.UserId);
                if(post.CategoryToolId != null)
                {
                    CategoryManager.CategoryToolCountPlus(db, post.CategoryToolId);
                }
                if (post.CategoryTypeId != null)
                {
                    CategoryManager.CategoryTypesCountPlus(db, post.CategoryTypeId);
                }

                db.Posts.Add(post);
                var count = db.SaveChanges();
                return post;
            }
        }
    }
}