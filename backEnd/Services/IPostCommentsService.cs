using System.Collections.Generic;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public interface IPostCommentsService
    {
        List<PostCommentsResult> GetComments(int postId);
        PostComments AddComment(PostComments comment);
        PostComments EditComment(PostComments comment);
        int CommentRemove(int commentId);
    }
}