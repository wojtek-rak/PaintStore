using System.Collections.Generic;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public interface ILikesService
    {
        List<LikesResult> GetPostLikes(int loggedUserId, int postId);
        PostLikes AddImageLike(PostLikes like);
        int RemoveImageLike(int userId, int postId);
        List<LikesResult> GetCommentLikes(int loggedUserId, int commentId);
        CommentLikes AddCommentLike(CommentLikes like);
        int RemoveCommentLike(int userId, int commentId);
    }
}