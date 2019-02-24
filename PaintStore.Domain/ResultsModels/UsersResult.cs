using PaintStore.Domain.Interfaces;

namespace PaintStore.Domain.ResultsModels
{
    public class UsersResult : IUsers
    {
        public bool Followed { get; set; }
        public UsersResult(IUsers iUsers)
        {
            Id = iUsers.Id;
            Name = iUsers.Name;
            Link = iUsers.Link;
            AvatarImgLink = iUsers.AvatarImgLink;
            BackgroundImgLink = iUsers.BackgroundImgLink;
            About = iUsers.About;
            PostsCount = iUsers.PostsCount;
            FollowedCount = iUsers.FollowedCount;
            FollowingCount = iUsers.FollowingCount;    
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string AvatarImgLink { get; set; }
        public string BackgroundImgLink { get; set; }
        public string About { get; set; }
        public int PostsCount { get; set; }
        public int FollowedCount { get; set; }
        public int FollowingCount { get; set; }
    }
}
