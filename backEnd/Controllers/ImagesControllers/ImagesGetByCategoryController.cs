using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.ImagesControllers
{
    [Route("api/[controller]")]
    public class ImagesGetByCategoryController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImagesGetByCategoryController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<PostsResults> GetImagesByCategory([FromBody] Message message)
        {
            using (var db = paintStoreContext)
            {

                List<PostsResults> imagesResult = new List<PostsResults>();
                IQueryable<Posts> images = null;
                if (message.Properties == "type")
                {
                    images = db.Posts.Where(
                        x => x.CategoryTypeId == db.CategoryTypes.
                        Where(y => y.TypeName == message.CategoryType).First().Id);
                }
                if (message.Properties == "tool")
                {
                    images = db.Posts.Where(
                        x => x.CategoryToolId == db.CategoryTools.
                        Where(y => y.ToolName == message.CategoryTool).First().Id);
                }
                if (message.Properties == "both")
                {
                    images = db.Posts.Where(
                        x => x.CategoryTypeId == db.CategoryTypes.
                        Where(y => y.TypeName == message.CategoryType).First().Id).
                        Where(x => x.CategoryToolId == db.CategoryTools.
                        Where(y => y.ToolName == message.CategoryTool).First().Id);
                }
                foreach (var image in images)
                {
                    var userOwnerImgLink = db.Users.First(x => x.Id == image.UserId).AvatarImgLink;
                    imagesResult.Add(new PostsResults(image){UserOwnerImgLink = userOwnerImgLink});
                }
                return imagesResult;

            }

        }
    }
}