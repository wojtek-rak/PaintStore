using System.Collections.Generic;
using PaintStore.Domain.Entities;

namespace PaintStore.Application.Interfaces
{
    public interface ITagsService
    {
        List<Tags> GetTags(int postId);
        Tags GetOrAddTag(string tagName);
        int AddPostTags(List<string> tagsList, int postId);

    }
}