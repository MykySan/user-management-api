using System.Collections.Generic;
using System.Linq;
using UserManagementAPI.Models;
using UserManagementAPI.Data;

namespace UserManagementAPI.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers() => UserData.Users;

        public User? GetUserById(int id) => UserData.Users.FirstOrDefault(u => u.Id == id);

        public User CreateUser(User user)
        {
            user.Id = UserData.Users.Count + 1;
            UserData.Users.Add(user);
            return user;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            var user = UserData.Users.FirstOrDefault(u => u.Id == id);
            if(user == null) return false;

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = UserData.Users.FirstOrDefault(u => u.Id == id);
            if(user == null) return false;
            UserData.Users.Remove(user);
            return true;
        }
    }
}