using System.Collections.Generic;
using UserManagementAPI.Models;

namespace UserManagementAPI.Data
{
    public static class UserData
    {
        public static List<User> Users = new()
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 25},
            new User { Id = 2, Name = "Alberto Bernoulli", Email = "AlbertoB@example.com", Age = 40},
            new User { Id = 3, Name = "Donald Pump", Email = "dopump@example.com", Age = 70}
        };
    }
}