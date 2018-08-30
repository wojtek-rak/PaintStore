using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.CommentsControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserEditController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public UserEditController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public Users EditUser([FromBody] Users user)
        {
            //todo better
            var userToUptade = paintStoreContext.Users.Where(x => x.Id == user.Id).First();
            if (user.About != null) userToUptade.About = user.About;
            if (user.AvatarImgLink != null) userToUptade.AvatarImgLink = user.AvatarImgLink;
            if (user.BackgroundImgLink != null) userToUptade.BackgroundImgLink = user.BackgroundImgLink;
            if (user.Name != null) userToUptade.Name = user.Name;
            if (user.Link != null) userToUptade.Link = user.Link;
            var count = paintStoreContext.SaveChanges();
            return userToUptade;
        }
    }
}
