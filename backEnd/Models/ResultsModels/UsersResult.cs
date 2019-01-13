using backEnd.Interfaces;

namespace backEnd.Models.ResultsModels
{
    public class UsersResult : Users
    {
        //public string MostUsedCategoryToolName { get; set; }
        public bool Followed { get; set; }
        public UsersResult(IUsers iUsers)
        {
            Id = iUsers.Id;
            AccountId = iUsers.AccountId;
            Name = iUsers.Name;
            Link = iUsers.Link;
            AvatarImgLink = iUsers.AvatarImgLink;
            BackgroundImgLink = iUsers.BackgroundImgLink;
            About = iUsers.About;
            PostsCount = iUsers.PostsCount;
            FollowedCount = iUsers.FollowedCount;
            FollowingCount = iUsers.FollowingCount;    
        }
    }
}
