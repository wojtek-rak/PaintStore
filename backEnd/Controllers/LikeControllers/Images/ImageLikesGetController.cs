using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.LikeControllers.Images
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImageLikesGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public ImageLikesGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<LikesResult> GetImageLikes([FromBody] Posts image)
        {
            using (var db = paintStoreContext)
            {
                var postLikesList = new List<LikesResult>();
                var likes = db.PostLikes.Where(b => b.PostId == image.Id).
                    OrderByDescending(postLikes => db.Users.First(user => user.Id == postLikes.UserId).FollowedCount);

                foreach (var like in likes)
                {
                    var user = db.Users.First(x => x.Id == like.UserId);
                    postLikesList.Add(new LikesResult(like.UserId, user.Name, user.AvatarImgLink));
                }
                return postLikesList;
            }

        }
    }
}