using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;
using SocialNetwork.Dtos;

namespace SocialNetwork.Repositories
{
    public interface IUserRepository
    {
        User AddUser(UserDto user);
        void DeleteUser(int userId);
        User GetUser(int id);
        bool UserNameIsUnique(string userName);
        List<User> GetAllUsers();
    }
}
