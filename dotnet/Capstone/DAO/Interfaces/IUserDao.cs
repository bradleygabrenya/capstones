using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IUserDao
    {
        User GetUser(string username);
        List<User> GetUsers();
        User AddUser(string username, string password, string role, string email, string workoutGoals, string workoutProfile, string photo);
        public void UpdateUserRole(User user);
        public void UpdateUserProfile(User user);
    }
}
