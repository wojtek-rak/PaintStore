using Microsoft.AspNetCore.Mvc;
using PaintStore.Application.Interfaces;
using PaintStore.Domain.InputModels;

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