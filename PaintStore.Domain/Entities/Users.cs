using System;
using PaintStore.Domain.Interfaces;

namespace PaintStore.Domain.Entities
{
    public partial class Users : IUsers, IUsersSearchResult
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordSoil { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
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
