using backEnd.Interfaces;

namespace backEnd.Models.ResultsModels
{
    public class SearchResult : ITagsSearchResult, IUsersSearchResult
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string AvatarImgLink { get; set; }
        public int FollowedCount { get; set; }
        public int Indexer {private get; set; }
        public int GetIndexer()
        {
            return Indexer;
        }

        public SearchResult(ITagsSearchResult iTag)
        {
            Id = iTag.Id;
            TagName = iTag.TagName;
            Count = iTag.Count;
            //Indexer = iType.Count;
        }
        

        public SearchResult(IUsersSearchResult iUser)
        {
            Id = iUser.Id;
            Name = iUser.Name;
            AvatarImgLink = iUser.AvatarImgLink;
            FollowedCount = iUser.FollowedCount;
            //Indexer = iUser.FollowedCount;
        }
    }
}
