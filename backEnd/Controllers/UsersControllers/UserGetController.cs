using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IQueryable<Users> GetUser([FromBody] string userLink)
        {
            using (var db = paintStoreContext)
            {
                var user = db.Users.Where(b => b.Link == userLink);
                return user;
            }

        }
    }
}
