using System.Collections.Generic;
using PaintStore.Domain.Entities;
using PaintStore.Domain.ResultsModels;

namespace PaintStore.Application.Interfaces
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