using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using SocialNetwork.Models;
using SocialNetwork.Dtos;


namespace SocialNetwork.Repositories
{
    public interface IPostRepository    {
        Post AddPost(PostDto postDto);
        void DeletePost(int postId, int userId);
        string GetAllPosts();
        Post GetPostById(int id);
        Post LikeOrUnlikePost(int postId, int userId);
        Post UpdateContent(int postId, string content, int userId);
    }
}

