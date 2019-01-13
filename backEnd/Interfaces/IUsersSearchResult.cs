namespace backEnd.Interfaces
{
    public interface IUsersSearchResult
    {
        int Id { get; set; }
        string Name { get; set; }
        string AvatarImgLink { get; set; }
        int FollowedCount { get; set; }
    }
}
