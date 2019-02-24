using System.Collections.Generic;
using PaintStore.Domain.Entities;
using PaintStore.Domain.InputModels;
using PaintStore.Domain.ResultsModels;

namespace PaintStore.Application.Interfaces
{
    public interface IUsersService
    {
        UsersResult GetUser(int loggedUserId, int userId);
        List<PostsResults> GetPosts(int userId, string message);
        Users AddUser(AddUserCommand user);
        Users EditUser(Users user);
        Users EditUserCredentials(Users account);
        Users RemoveUser(Users account);
    }
}