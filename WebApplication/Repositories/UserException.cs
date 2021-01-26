using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
        }
    }
    public class NonUniqueUserName : UserException
    {
        public NonUniqueUserName(string message = "Enter uniqe User name") : base(message)
        {
        }
    }

    public class NonUniqueId : UserException
    {
        public NonUniqueId(string message = "Id is not unique") : base(message)
        {
        }
    }
    public class InvalidCharacters : UserException
    {
        public InvalidCharacters(string message = "Enter letters and numbers") : base(message)
        {
        }
    }
    public class UserNotFound : UserException
    {
        public UserNotFound(string message = "User not found") : base(message)
        {
        }
    }
}
