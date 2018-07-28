using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    public interface IDateTime
    {
        string Now();
    }
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentsAddController : Controller
    {
        private readonly IDateTime _dateTime;
        private readonly PaintStoreContext paintStoreContext;
   
            public CommentsAddController(PaintStoreContext ctx, IDateTime dateTime)
        {
                paintStoreContext = ctx;
                _dateTime = dateTime;
        }


    }
}