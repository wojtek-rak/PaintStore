using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public UserAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpPost]
        public Users AddUser([FromBody] Users user)
        {
            paintStoreContext.Users.Add(user);
            var count = paintStoreContext.SaveChanges();
            return user;
        }
    }
}
