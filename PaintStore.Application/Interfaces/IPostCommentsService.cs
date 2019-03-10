using System.Collections.Generic;
using PaintStore.Domain.Entities;
using PaintStore.Domain.InputModels;
using PaintStore.Domain.ResultsModels;

namespace PaintStore.Application.Interfaces
{
    public interface IPostCommentsService
    {
        List<PostCommentsResult> GetComments(int userId, int postId);
        PostComments AddComment(AddPostCommentCommand comment);
        PostComments EditComment(EditPostCommentCommand comment);
        int CommentRemove(int commentId);
    }
}