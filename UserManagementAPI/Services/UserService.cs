using UserManagementAPI.Models;
using UserManagementAPI.Repositories;

namespace UserManagementAPI.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetUsers() => _userRepository.GetUsers();

        public User? GetUserById(int id) => _userRepository.GetUserById(id);
    
        public User CreateUser(User user) => _userRepository.CreateUser(user);

        public bool UpdateUser(int id, User updatedUser) => _userRepository.UpdateUser(id, updatedUser);

        public bool DeleteUser(int id) => _userRepository.DeleteUser(id);
    }
}