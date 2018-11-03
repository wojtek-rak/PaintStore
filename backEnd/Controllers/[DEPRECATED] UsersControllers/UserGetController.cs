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
    public class UserGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public UserGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public IEnumerable<UsersResult> GetUser([FromBody] Users user)
        {
            List<UsersResult> usersResult = new List<UsersResult>();
            using (var db = paintStoreContext)
            {
                var userToGet = db.Users.First(b => b.Id == user.Id);
                
                //userToGet.MostUsedCategoryToolName = db.Posts.Where(x => x.UserId == user.Id).GroupBy(x => x.CategoryToolId);

                var toolId = db.Posts.Where(x => x.UserId == user.Id)
                    .Where(x => x.CategoryToolId != null)
                    .GroupBy(post => post.CategoryToolId)
                    .Select(group => new
                    {
                        ToolId = group.Key,
                        Count =  group.Count()
                    })
                    .OrderByDescending(y => y.Count)
                    .First().ToolId;
                if (toolId != null)
                {
                    usersResult.Add(new UsersResult(userToGet)
                    {
                        MostUsedCategoryToolName = db.CategoryTools.First(x => x.Id == toolId).ToolName
                    });
                }
                else usersResult.Add(new UsersResult(userToGet));
                return usersResult;
            }

        }
    }
}

