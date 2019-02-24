using PaintStore.Domain.Interfaces;

namespace PaintStore.Domain.ResultsModels
{

    public class PostsResults : IPosts
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserOwnerName { get; set; }
        public string UserOwnerImgLink { get; set; }
        public string Title { get; set; }
        public string ImgLink { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public int CommentsCount { get; set; }

        public PostsResults(IPosts  iPosts)
        {
            Id = iPosts.Id;
            UserId = iPosts.UserId;
            UserOwnerName = iPosts.UserOwnerName;
            Title = iPosts.Title;
            ImgLink = iPosts.ImgLink;
            LikeCount = iPosts.LikeCount;
            ViewCount = iPosts.ViewCount;
            CommentsCount = iPosts.CommentsCount;
        }
    }
}
