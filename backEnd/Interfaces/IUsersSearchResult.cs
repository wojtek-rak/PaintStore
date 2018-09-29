using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
