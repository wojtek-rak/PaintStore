using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public interface IFollowersService
    {
        List<LikesResult> GetFollowedUser(int userId);
        List<LikesResult> GetFollowingUser(int userId);
        UserFollowers AddFollower(UserFollowers follow);
        int FollowRemove(int userIdFollowing, int userIdFollowed);


    }
}
