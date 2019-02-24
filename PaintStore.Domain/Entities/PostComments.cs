using System;
using PaintStore.Domain.Interfaces;

namespace PaintStore.Domain.Entities
{
    public partial class PostComments : IPostComments
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public bool? Edited { get; set; }
    }
}
