//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using backEnd.Models;
//using backEnd.Models.ResultsModels;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//////////////////////////////////////////////////////////////
////                                                        //
////                        DEPRECATED                      //
////                                                        //
//////////////////////////////////////////////////////////////


//namespace backEnd.Controllers.LikeControllers.Comment
//{
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    [ApiExplorerSettings(IgnoreApi = true)]
//    public class CommentsLikesGetController : Controller
//    {
//        private readonly PaintStoreContext paintStoreContext;

//        public CommentsLikesGetController(PaintStoreContext ctx)
//        {
//            paintStoreContext = ctx;
//        }

//        [HttpPost]
//        public IEnumerable<LikesResult> GetCommentLikes([FromBody] PostComments comment)
//        {
//            using (var db = paintStoreContext)
//            {
//                var commentLikesList = new List<LikesResult>();
//                var likes = db.CommentLikes.Where(b => b.CommentId == comment.Id)
//                    .OrderByDescending(commentLikes => db.Users.First(user => user.Id == commentLikes.UserId).FollowedCount);
//                foreach (var like in likes)
//                {
//                    var user = db.Users.First(x => x.Id == like.UserId);
//                    commentLikesList.Add(new LikesResult(like.UserId, user.Name, user.AvatarImgLink));
//                }
//                return commentLikesList;
//            }

            
//        }
//    }
//}