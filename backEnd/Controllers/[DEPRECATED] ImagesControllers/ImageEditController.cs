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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImageEditController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageEditController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public Posts EditPost([FromBody] Posts post)
        {
            var postToUptade = paintStoreContext.Posts.Where(x => x.Id == post.Id).First();

            if (post.Title != null) postToUptade.Title = post.Title;
            if (post.Description != null) postToUptade.Description = post.Description;
            if (post.CategoryTypeId != null)
            {
                if (postToUptade.CategoryTypeId != null) CategoryManager.CategoryTypesCountMinus(paintStoreContext, postToUptade.CategoryTypeId);
                postToUptade.CategoryTypeId = post.CategoryTypeId;
                CategoryManager.CategoryTypesCountPlus(paintStoreContext, postToUptade.CategoryTypeId);
            }
            if (post.CategoryToolId != null)
            {
                if (postToUptade.CategoryToolId != null) CategoryManager.CategoryToolCountMinus(paintStoreContext, postToUptade.CategoryToolId);
                postToUptade.CategoryToolId = post.CategoryToolId;
                CategoryManager.CategoryToolCountPlus(paintStoreContext, postToUptade.CategoryToolId);
            }
            var count = paintStoreContext.SaveChanges();
            return postToUptade;
        }
    }
}
