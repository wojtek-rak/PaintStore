using System;

namespace backEnd.Interfaces
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
