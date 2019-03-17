using System.Collections.Generic;
using System.Linq;
using PaintStore.Application.Interfaces;
using PaintStore.Application.Managers;
using PaintStore.Domain.Entities;
using PaintStore.Persistence;

namespace PaintStore.Application.Services
{
    public class TagsService : ITagsService
    {
        private readonly PaintStoreContext _paintStoreContext;
        public TagsService(PaintStoreContext ctx)
        {
            _paintStoreContext = ctx;
        }

        public List<Tags> GetTags(int postId)
        {
            using (var db = _paintStoreContext)
            {
                var tags = db.PostTags.Where(x => x.PostId == postId).Select(y => y.TagId).ToList();
                var tagsList = db.Tags.Where(tag =>
                    tags.Contains(tag.Id)).ToList();
                return tagsList;
            }

        }

        public Tags GetOrAddTag(string tagName, PaintStoreContext db)
        {
            Tags tag = null;

            if (!db.Tags.Any(x => x.TagName == tagName))
            {
                tag = new Tags { TagName = tagName};
                db.Tags.Add(tag);
                db.SaveChanges();
            }

            if (db.Tags.Any(x => x.TagName == tagName))
            {
                tag = db.Tags.First(x => x.TagName == tagName);
            }


            return tag;

        }

        public int AddPostTags(List<string> tagsList, int postId)
        {

            using(var db = _paintStoreContext)
            {
                var tagsToRemove = db.PostTags.Where(x => x.PostId == postId).ToList();
                foreach (var tagToRemove in tagsToRemove)
                {
                    db.PostTags.Remove(tagToRemove);
                    TagsManager.TagsCountMinus(db, tagToRemove.TagId);
                }

                foreach (var tag in tagsList)
                {
                    var tagToAdd = GetOrAddTag(tag, db);
                    db.PostTags.Add(new PostTags {PostId = postId, TagId = tagToAdd.Id});
                    TagsManager.TagsCountPlus(db, tagToAdd.Id);
                }
                db.SaveChanges();
            }
            return postId;
        }
        
    }
}