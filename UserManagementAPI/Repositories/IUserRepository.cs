using System.Collections.Generic;
using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User? GetUserById(int id);
        User CreateUser(User user);
        bool UpdateUser(int id, User updatedUser);
        bool DeleteUser(int id);
    }
}