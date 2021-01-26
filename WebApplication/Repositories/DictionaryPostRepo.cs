using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using SocialNetwork.Repositories;
using SocialNetwork.Models;
using SocialNetwork.Dtos;

namespace SocialNetwork.Repositories
{
    public class DictionaryPostRepo : IPostRepository
    {
        private readonly IUserRepository _userRepository = new DictionaryUserRepo();
        private readonly Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        public DictionaryPostRepo(IUserRepository dictionaryUserRepository)
        {
            var user1 = dictionaryUserRepository.GetUser(1);
            var post1 = new Post(1)
            {
                Content = "which actor do you like!",
                UserId = user1.UserId,
            };
            var user2 = dictionaryUserRepository.GetUser(2);
            var post2 = new Post(2)
            {
                Content = "Life is Like riding a bicycle!",
                UserId = user2.UserId,
            };
            var user3 = dictionaryUserRepository.GetUser(3);
            var post3 = new Post(3)
            {
                Content = "Book is my best friend, what about you!",
                UserId = user3.UserId,
            };

            _posts.Add(1, post1);
            _posts.Add(2, post2);
            _posts.Add(3, post3);
        }
        public string GetAllPosts()
        {
            string posts = string.Empty;
            foreach (var post in _posts)
            {
                posts += JsonConvert.SerializeObject(post.Value, Formatting.Indented);
            }
            return posts;
        }
        public Post GetPostById(int id)
        {
            return _posts[id];
        }
        public Post AddPost(PostDto postDto)
        {
            var id = _posts.Count + 1;
            var post = new Post(id, postDto, _userRepository);
            _posts.Add(id, post);
            return post;
        }
        public Post LikeOrUnlikePost(int postId, int userId)
        {
            Post post = GetPostById(postId);
            User user = _userRepository.GetUser(userId);
            if (!post.Likes.Contains(user))
            {
                post.Likes.Add(user);
            }
            else
            {
                post.Likes.Remove(user);
            }
            return post;
        }
        public Post UpdateContent(int postId, string newContent, int userId)
        {
            if (!CorrectUser(postId, userId))
            {
                throw new NotCorrectUser();
            }
            var post = GetPostById(postId);
            post.Content = newContent;
            post.LastDate = DateTime.Now;
            return post;
        }

        public bool CorrectUser(int postId, int userId)
        {
            Post post = GetPostById(postId);
            User user = _userRepository.GetUser(userId);
            if (post.UserId == user.UserId)
            {
                return true;
            }
            else
                return false;
        }
        public void DeletePost(int postId, int userId)
        {
            if (!CorrectUser(postId, userId))
            {
                throw new NotCorrectUser();
            }
            _posts.Remove(postId);
        }
    }
}
