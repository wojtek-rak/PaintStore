namespace backEnd.Models.ResultsModels
{
    public class LikesResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string AvatarImgLink { get; set; }
        public bool Followed { get; set; }

        public LikesResult(int userId, string name, string avatarImgLink, bool followed)
        {
            UserId = userId;
            Name = name;
            AvatarImgLink = avatarImgLink;
            Followed = followed;
        }
    }
}
