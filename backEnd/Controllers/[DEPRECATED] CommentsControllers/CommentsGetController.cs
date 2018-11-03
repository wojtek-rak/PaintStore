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
    /// <summary>
    ///  Use /api/CommentsGet to get comments with POST string
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentsGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public CommentsGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<PostCommentsResult> GetComments([FromBody] Posts post)//([FromBody] string imgLink)
        {
            List<PostCommentsResult> commentsResult = new List<PostCommentsResult>();
            using (var db = paintStoreContext)
            {
                var comments = db.PostComments.Where(b => b.PostId == post.Id).OrderByDescending(x => x.LikeCount);
                foreach (var comment in comments)
                {
                    var userAvatarImgLink = db.Users.First(x => x.Id == comment.UserId).AvatarImgLink;
                    commentsResult.Add(new PostCommentsResult(comment){UserOwnerImgLink = userAvatarImgLink});
                }
                return commentsResult;
            }

        }
    }  
}