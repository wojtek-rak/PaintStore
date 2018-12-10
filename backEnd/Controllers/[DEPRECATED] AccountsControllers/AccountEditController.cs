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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
            var accountToUpdate = paintStoreContext.Accounts.First(x => x.Id == account.Id);
            if (account.Email != null) accountToUpdate.Email = account.Email;
            if (account.PasswordHash != null) accountToUpdate.PasswordHash = account.PasswordHash;
            var count = paintStoreContext.SaveChanges();
            return accountToUpdate;
        }
    }
}

