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
        public IEnumerable<Users> GetUser([FromBody] Users user)
        {
            using (var db = paintStoreContext)
            {
                var userToGet = db.Users.Where(b => b.Id == user.Id);
                return userToGet.ToList();
            }

        }
    }
}
