using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 25},
                new User { Id = 2, Name = "Alberto Bernoulli", Email = "AlbertoB@example.com", Age = 40},
                new User { Id = 3, Name = "Donald Pump", Email = "dopump@example.com", Age = 70}
            };
        }

        public IEnumerable<User> GetUsers() => _users;

        public User? GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);
    
        public User CreateUser(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return user;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            _users.Remove(user);
            return true;
        }
    }
}