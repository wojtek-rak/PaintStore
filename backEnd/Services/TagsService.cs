using System.Collections.Generic;
using System.Linq;
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

        public List<Tags> GetTags(int postId)
        {
            using (var db = paintStoreContext)
            {
                var tags = db.PostTags.Where(x => x.PostId == postId).Select(y => y.TagId).ToList();
                var tagsList = db.Tags.Where(tag =>
                    tags.Contains(tag.Id)).ToList();
                return tagsList;
            }

        }

        public Tags AddTag(Tags tag)
        {
            using(var db = paintStoreContext)
            {
                db.Tags.Add(tag);
                var count = db.SaveChanges();
            }
            return tag;
        }
    }
}