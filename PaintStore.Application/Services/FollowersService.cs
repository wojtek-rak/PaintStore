using System.Collections.Generic;
using System.Linq;
using PaintStore.Application.Interfaces;
using PaintStore.Application.Managers;
using PaintStore.Domain.Entities;
using PaintStore.Domain.Exceptions;
using PaintStore.Domain.ResultsModels;
using PaintStore.Persistence;

namespace PaintStore.Application.Services
{
    public class FollowersService : IFollowersService
    {
        private readonly PaintStoreContext paintStoreContext;
        public FollowersService(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        public List<LikesResult> GetFollowedUser(int loggedUserId, int userId)
        {
            var followsList = new List<LikesResult>();
            using (var db = paintStoreContext)
            {
                var follows = db.UserFollowers.Where(b => b.FollowedUserId == userId)
                    .OrderByDescending(following => db.Users.First(userF => userF.Id == following.FollowingUserId).FollowedCount);
                foreach (var follow in follows)
                {
                    var userTemp = db.Users.First(x => x.Id == follow.FollowingUserId);
                    bool followed = db.UserFollowers.Any(x => x.FollowedUserId == userTemp.Id && x.FollowingUserId == loggedUserId);
                    followsList.Add(new LikesResult(follow.FollowingUserId, userTemp.Name, userTemp.AvatarImgLink, followed));
                }
            }
            return followsList;
        }

        public List<LikesResult> GetFollowingUser(int loggedUserId, int userId)
        {
            using (var db = paintStoreContext)
            {
                var followsList = new List<LikesResult>();
                var follows = db.UserFollowers.Where(b => b.FollowingUserId == userId)
                    .OrderByDescending(followed => db.Users.First(userF => userF.Id == followed.FollowedUserId).FollowedCount);
                foreach (var follow in follows)
                {
                    var userTemp = db.Users.First(x => x.Id == follow.FollowedUserId);
                    bool followed = db.UserFollowers.Any(x => x.FollowedUserId == userTemp.Id && x.FollowingUserId == loggedUserId);
                    followsList.Add(new LikesResult(follow.FollowedUserId, userTemp.Name, userTemp.AvatarImgLink, followed));
                }
                return followsList;
            }
        }

        public UserFollowers AddFollower(UserFollowers follow)
        {
            using (var db = paintStoreContext)
            {
                if ((db.UserFollowers.Any(x =>
                    x.FollowedUserId == follow.FollowedUserId && x.FollowingUserId == follow.FollowingUserId))
                    || follow.FollowedUserId == follow.FollowingUserId)
                {
                    throw new NegotiatedContentResultException();
                }
                FollowersManager.UserFollowedCountPlus(db, follow.FollowedUserId);
                FollowersManager.UserFollowingCountPlus(db, follow.FollowingUserId);
                db.UserFollowers.Add(follow);
                db.SaveChanges();
            }
            return follow;
        }

        public int FollowRemove(int userIdFollowing, int userIdFollowed)
        {
            using (var db = paintStoreContext)
            {
                var followId = db.UserFollowers
                    .First(x => x.FollowingUserId == userIdFollowing && x.FollowedUserId == userIdFollowed).Id;

                var tempFollow = db.UserFollowers.First(x => x.Id == followId);
                FollowersManager.UserFollowedCountMinus(db, tempFollow.FollowedUserId);
                FollowersManager.UserFollowingCountMinus(db, tempFollow.FollowingUserId);
                db.UserFollowers.Remove(db.UserFollowers.First(x => x.Id == followId));
                db.SaveChanges();
                return followId;
            }
        }
    }
}
