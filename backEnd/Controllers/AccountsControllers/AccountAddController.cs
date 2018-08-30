using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.CommentsControllers
{
    [Route("api/[controller]")]
    public class AccountAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public AccountAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpPost]
        public Accounts AddAccount([FromBody] Accounts account)
        {
            paintStoreContext.Accounts.Add(account);
            var count = paintStoreContext.SaveChanges();
            return account;
        }
    }
}

