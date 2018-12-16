using System.Collections.Generic;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public interface IUsersService
    {
        UsersResult GetUser(int loggedUserId, int userId);
        List<PostsResults> GetPosts(int userId, string message);
        Users AddUser(Users user);
        Users EditUser(Users user);
    }
}