﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class User
    {
        private const string _stringMessage = "{0} error: Enter characters long between {1}-{2}";
        public User(int id, string username, string password, string emailadress)
        {
            UserId = id;
            UserName = username;
            Password = password;
            EmailAdress = emailadress;
        }
        public User()
        {

        }
        public int UserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
