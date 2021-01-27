using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace SocialNetwork.Repositories
{
    public class PostException : Exception
    {
        public PostException(string message) : base(message)
        {

        }
    }
    public class ContentAmountOfCharacters : PostException
    {
        public ContentAmountOfCharacters(string message = "Enter between 5-150 characters") : base(message)
        {

        }
    }
    public class NotCorrectUser : PostException
    {
        public NotCorrectUser(string message = "There is no acess...") : base(message)
        {

        }
    }
}
