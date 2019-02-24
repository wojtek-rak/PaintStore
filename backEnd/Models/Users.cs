using System;
using backEnd.Interfaces;

namespace backEnd.Models
{
    public partial class Users : IUsers, IUsersSearchResult
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordSoil { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationDate { get; set; }
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
