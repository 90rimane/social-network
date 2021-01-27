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
        void AddPost(PostDto postDto);
        void DeletePost(int postId, int userId);
        List<Post> GetAllPosts();
        Post GetPostById(int id);
        Post LikeOrUnlikePost(int postId, int userId);
        Post UpdateContent(int postId, PostDto postDto);
    }
}

