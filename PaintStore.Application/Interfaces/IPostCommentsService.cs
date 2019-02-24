using System.Collections.Generic;
using PaintStore.Domain.Entities;
using PaintStore.Domain.ResultsModels;

namespace PaintStore.Application.Interfaces
{
    public interface IPostCommentsService
    {
        List<PostCommentsResult> GetComments(int userId, int postId);
        PostComments AddComment(PostComments comment);
        PostComments EditComment(PostComments comment);
        int CommentRemove(int commentId);
    }
}