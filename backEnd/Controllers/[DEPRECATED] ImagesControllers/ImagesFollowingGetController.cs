using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ImagesFollowingGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImagesFollowingGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<PostsResults> GetImages([FromBody] Users user)
        {
            List<PostsResults> imagesResult = new List<PostsResults>();
            using (var db = paintStoreContext)
            {
                //IQueryable<Posts> images = null;
                var images = db.Posts.
                    Where(x => db.UserFollowers.
                    Where(y => y.FollowingUserId == user.Id).
                    Select(z => z.FollowedUserId).Contains(x.UserId)).
                    OrderByDescending(x => x.CreationDate);
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

