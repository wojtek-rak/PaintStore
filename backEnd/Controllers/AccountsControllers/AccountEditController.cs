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
    public class AccountEditController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public AccountEditController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public Accounts EditAccount([FromBody] Accounts account)
        {
            //todo better
            var accountToUptade = paintStoreContext.Accounts.Where(x => x.Id == account.Id).First();
            if (account.Email != null) accountToUptade.Email = account.Email;
            if (account.PasswordHash != null) accountToUptade.PasswordHash = account.PasswordHash;
            var count = paintStoreContext.SaveChanges();
            return accountToUptade;
        }
    }
}

