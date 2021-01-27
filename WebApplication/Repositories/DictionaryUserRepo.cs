using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Dtos;
using SocialNetwork.Models;

namespace SocialNetwork.Repositories
{
    public class DictionaryUserRepo /*: IUserRepository*/
    {
        private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public DictionaryUserRepo()
        {
            var user1 = new User
            {
                UserId = 1,
                UserName = "Ali",
                Password = "AlisPassword",
                EmailAdress = "ali@gmail.com"
            };
            var user2 = new User
            {
                UserId = 2,
                UserName = "Atena",
                Password = "AtenasPassword",
                EmailAdress = "atena@gmail.com"
            };
            var user3 = new User
            {
                UserId = 3,
                UserName = "Tim",
                Password = "TimsPassword",
                EmailAdress = "tim@gmail.com"
            };

            _users.Add(1, user1);
            _users.Add(2, user2);
            _users.Add(3, user3);
        }
        public User GetUser(int id)
        {
            try
            {
                return _users[id];
            }
            catch (KeyNotFoundException)
            {
                throw new UserNotFound();
            }
        }
        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        public bool UserNameIsUnique(User userName)
        {
            return _users.Any(e => String.Equals(e.Value.UserName, userName.UserName, StringComparison.CurrentCultureIgnoreCase));
        }
        public int ValidateUniqueId(int id)
        {
            bool isOkay = false;
            while (!isOkay)
            {
                isOkay = true;
                if (_users.Any(e => e.Value.UserId == id))
                {
                    id += 1;
                    isOkay = false;
                }
            }
            return id;
        }

        public void AddUser(UserDto userDto)
        {
            var id = _users.Count + 1;
            id = ValidateUniqueId(id);
            var user = new User(id, userDto.UserName, userDto.Password, userDto.EmailAdress);
            bool usernameOkay = UserValidation.ValidateUsername(userDto.UserName);
            if (!usernameOkay)
            {
                throw new InvalidCharacters();
            }
            if (UserNameIsUnique(user))
            {
                throw new NonUniqueUserName();
            }
            if (_users.ContainsKey(user.UserId))
            {
                throw new NonUniqueId();
            }
            _users.Add(id, user);

        }

        public void DeleteUser(int userId)
        {
            _users.Remove(userId);
        }
    }
}

