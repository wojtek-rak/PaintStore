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
        List<LikesResult> GetFollowedUser(int loggedUserId, int userId);
        List<LikesResult> GetFollowingUser(int loggedUserId, int userId);
        UserFollowers AddFollower(UserFollowers follow);
        int FollowRemove(int userIdFollowing, int userIdFollowed);


    }
}
