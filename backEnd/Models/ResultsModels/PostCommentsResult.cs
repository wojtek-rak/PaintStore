using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Interfaces;

namespace backEnd.Models.ResultsModels
{
    public class PostCommentsResult : IPostComments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserAvatarImgLink { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }

        public PostCommentsResult(IPostComments iPostComments)
        {
            Id = iPostComments.Id;
            UserId = iPostComments.UserId;
            CreationDate = iPostComments.CreationDate;
            Content = iPostComments.Content;
            LikeCount = iPostComments.LikeCount;
        }
    }
}
