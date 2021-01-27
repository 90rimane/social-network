using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using SocialNetwork.Models;
using SocialNetwork.Dtos;


namespace SocialNetwork.Repositories
{
    public interface IPostRepository    
    {
        Post GetPostById(int id);
        List<Post> GetAllPosts();
        void AddPost(PostDto postDto);
        Post UpdateContent(int postId, PostDto postDto);
        void DeletePost(int postId, int userId);
        Post LikeOrDislikePost(int postId, int userId);
    }
}

