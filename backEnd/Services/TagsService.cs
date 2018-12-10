using backEnd.Controllers;
using backEnd.Models;

namespace backEnd.Services
{
    public class TagsService : ITagsService
    {
        private readonly PaintStoreContext paintStoreContext;
        public TagsService(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
    }
}