﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Dtos
{
    public class UserDto
    {
        private const string _stringMessage = "{0} error: Enter characters long between {1}-{2}";
        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }
    }
}
