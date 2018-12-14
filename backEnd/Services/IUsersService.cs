using System.Collections.Generic;
using backEnd.Models;
using backEnd.Models.ResultsModels;

namespace backEnd.Services
{
    public interface IUsersService
    {
        UsersResult GetUser(int loggedUserId, int userId);
        List<Posts> GetPosts(int userId);
        Users AddUser(Users user);
        Users EditUser(Users user);
    }
}