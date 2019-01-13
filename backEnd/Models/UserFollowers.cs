namespace backEnd.Models
{
    public partial class UserFollowers
    {
        public int Id { get; set; }
        public int FollowedUserId { get; set; }
        public int FollowingUserId { get; set; }
    }
}
