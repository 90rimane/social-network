using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Dtos;
using SocialNetwork.Repositories;

namespace SocialNetwork.Models
{
    public class Post
    {
        private const string _stringMessage = "{0} error: Enter characters long between {1}-{2}";

        public Post()
        {

        }
        public Post(PostDto postDto)
        {
            Content = postDto.Content;
            UserId = postDto.UserId;
        }
        public Post(int id)
        {
            PostId = id;
        }
        public Post(int id, PostDto postDto)
        {
            PostId = id;
            Content = postDto.Content;
            UserId = postDto.UserId;
        }
        public int PostId { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime? LastDate { get; set; } = null;

        [Required]
        public int UserId { get; set; }
        public List<User> Likes { get; set; } = new List<User>();
    }
}
