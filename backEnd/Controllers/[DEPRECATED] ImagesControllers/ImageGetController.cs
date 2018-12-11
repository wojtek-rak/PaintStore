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


//namespace backEnd.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiExplorerSettings(IgnoreApi = true)]
//    public class ImageGetController : Controller
//    {
//        private readonly PaintStoreContext paintStoreContext;

//        public ImageGetController(PaintStoreContext ctx)
//        {
//            paintStoreContext = ctx;
//        }

//        [HttpPost]
//        public IEnumerable<PostDetailsResult> GetImage([FromBody] Posts image)
//        {
//            List<PostDetailsResult> postDetailsResult = new List<PostDetailsResult>();
//            using (var db = paintStoreContext)
//            {
//                var posts = db.Posts.Where(b => b.Id == image.Id);
//                foreach (var post in posts)
//                {
//                    var categoryTypeName = post.CategoryTypeId == null ? null : 
//                        db.CategoryTypes.First(x => x.Id == post.CategoryTypeId).TypeName;
//                    var categoryToolName = post.CategoryToolId == null ? null : 
//                        db.CategoryTools.First(x => x.Id == post.CategoryToolId).ToolName;
//                    postDetailsResult.Add(new PostDetailsResult(post)
//                    {
//                        CreationDate = post.CreationDate,
//                        Description = post.Description,
//                        CategoryTypeName = categoryTypeName,
//                        CategoryToolName = categoryToolName
                        
//                    });
//                }
//                return postDetailsResult;
//            }

//        }
//    }
//}