using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Dtos
{
    public class PostDto
    {
        private const string _stringMessage = "{0} error: Enter characters long between {1}-{2}";

        [Required]
        [StringLength(400, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
