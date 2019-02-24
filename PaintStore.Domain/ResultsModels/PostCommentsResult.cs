using System;
using PaintStore.Domain.Interfaces;

namespace PaintStore.Domain.ResultsModels
{
    public class PostCommentsResult : IPostComments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserOwnerImgLink { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public bool Liked { get; set; }
        public bool? Edited { get; set; }

        public PostCommentsResult(IPostComments iPostComments)
        {
            Id = iPostComments.Id;
            UserId = iPostComments.UserId;
            CreationDate = iPostComments.CreationDate;
            Content = iPostComments.Content;
            LikeCount = iPostComments.LikeCount;
            Edited = iPostComments.Edited;
            
        }
    }
}
