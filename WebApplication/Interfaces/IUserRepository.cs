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
        User GetUser(int id);
        List<User> GetAllUsers();
        void AddUser(UserDto user);
        void DeleteUser(int userId);
        public bool UserNameIsUnique(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
