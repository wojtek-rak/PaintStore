using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models.InputModels;
using backEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService; 
        }
        [HttpPost("AddPostTags")]
        public IActionResult AddTagsToPost([FromBody] PostAddTags postAddTags)
        {
            return Ok(_tagsService.AddPostTags(postAddTags.TagsList, postAddTags.PostId));
        }
    }
}