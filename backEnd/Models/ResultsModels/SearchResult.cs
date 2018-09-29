using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Interfaces;

namespace backEnd.Models.ResultsModels
{
    public class SearchResult : ITypeSearchResult, IUsersSearchResult
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string AvatarImgLink { get; set; }
        public int FollowedCount { get; set; }
        public int Indexer {private get; set; }
        public int GetIndexer()
        {
            return Indexer;
        }

        public SearchResult(ITypeSearchResult iType)
        {
            Id = iType.Id;
            TypeName = iType.TypeName;
            Count = iType.Count;
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
