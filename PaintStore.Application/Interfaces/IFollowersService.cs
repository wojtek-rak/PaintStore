using System.Collections.Generic;
using PaintStore.Domain.Entities;
using PaintStore.Domain.ResultsModels;

namespace PaintStore.Application.Interfaces
{
    public interface IFollowersService
    {
        List<LikesResult> GetFollowedUser(int loggedUserId, int userId);
        List<LikesResult> GetFollowingUser(int loggedUserId, int userId);
        UserFollowers AddFollower(UserFollowers follow);
        int FollowRemove(int userIdFollowing, int userIdFollowed);


    }
}
