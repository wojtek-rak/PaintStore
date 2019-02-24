using System;

namespace PaintStore.Domain.Interfaces
{
    public interface IPostComments
    {
        int Id { get; set; }
        int UserId { get; set; }
        DateTime CreationDate { get; set; }
        string Content { get; set; }
        int LikeCount { get; set; }
        bool? Edited { get; set; }
    }
}
