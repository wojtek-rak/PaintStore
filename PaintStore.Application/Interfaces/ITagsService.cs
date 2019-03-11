using System.Collections.Generic;
using PaintStore.Domain.Entities;
using PaintStore.Persistence;

namespace PaintStore.Application.Interfaces
{
    public interface ITagsService
    {
        List<Tags> GetTags(int postId);
        Tags GetOrAddTag(string tagName, PaintStoreContext db);
        int AddPostTags(List<string> tagsList, int postId);

    }
}