using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SocialNetwork.Repositories
{
    public class UserValidation
    {
        public static bool ValidateUsername(string username)
        {
            bool isOkay = true;
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
                isOkay = false;
            return isOkay;
        }
    }
}
