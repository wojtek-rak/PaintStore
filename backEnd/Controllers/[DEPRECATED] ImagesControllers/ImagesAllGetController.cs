using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Interfaces;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

////////////////////////////////////////////////////////////
//                                                        //
//                        DEPRECATED                      //
//                                                        //
////////////////////////////////////////////////////////////


namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    public class ImagesAllGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImagesAllGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<PostsResults> GetAllImages([FromBody] Message message)
        {
            using (var db = paintStoreContext)
            {
                List<PostsResults> imagesResult = new List<PostsResults>();
                IQueryable<IPosts> images = null;
                if (message.Properties == "most_popular")
                {
                    images = db.Posts.OrderByDescending(y => (db.PostComments.Count(x => x.PostId == y.Id)));
                }
                if (message.Properties == "the_newest")
                {
                    images = db.Posts.OrderByDescending(x => x.CreationDate);
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