﻿using Dapper;
using Microsoft.Data.Sqlite;
using SocialNetwork.Dtos;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Repositories;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public class SqlPostRepository : IPostRepository
    {
        private readonly IUserRepository _userRepository ;
        private const string _connectionString = "Data Source=.\\SocialNetwork.db";
        public void AddPost(PostDto postDto)
        {
            var post = new Post(postDto);
            using var connection = new SqliteConnection(_connectionString);
            var sql = "INSERT INTO Post (Content, CreatedDate, LastDate, UserId) VALUES(@Content, DATETIME('now'), @LastDate, @UserId)";
            connection.Execute(sql, post);
        }
        public void DeletePost(int postId, int userId)
        {
            var post = GetPostById(postId);
            var user = _userRepository.GetUser(userId);
            if (post.UserId == user.UserId)
            {
                using var connection = new SqliteConnection(_connectionString);
                var sql = $"DELETE FROM post WHERE PostId = @PostId";
                connection.Execute(sql, post);
            }
            else
                throw new NotCorrectUser();
        }
        public List<Post> GetAllPosts()
        {
            using var connection = new SqliteConnection(_connectionString);
            var posts = connection.Query<Post>($"SELECT * FROM Post");
            var likes = connection.Query<Like>($"SELECT * FROM Likes");
            likes.ToList();
            posts.ToList();
            foreach (var like in likes)
            {
                foreach (var post in posts)
                {
                    if (like.PostId == post.PostId)
                        post.Likes.Add(_userRepository.GetUser(like.UserId));
                }
            }
            return posts.ToList();
        }
        public Post GetPostById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var posts = connection.Query<Post>("SELECT * FROM Post");
            var likes = connection.Query<Like>("SELECT * FROM Likes");
            likes.ToList();
            posts.ToList();
            if (!posts.Any(e => e.PostId == id))
            {
                throw new NotCorrectUser();
            }
            var post = new Post();
            foreach (var tmpPost in posts)
            {
                if (tmpPost.PostId == id)
                    post = tmpPost;
            }
            foreach (var like in likes)
            {
                if (like.PostId == post.PostId)
                {
                    post.Likes.Add(_userRepository.GetUser(like.UserId));
                }
            }
            return post;
        }
        public Post LikeOrDislikePost(int postId, int userId)
        {
            var user = _userRepository.GetUser(userId);
            var post = GetPostById(postId);
            bool alreadyLiked = false;
            using var connection = new SqliteConnection(_connectionString);
            var sql = $"SELECT * FROM Likes WHERE Likes.PostId = @PostId";
            var likes = connection.Query<Like>(sql, post);
            likes.ToList();
            foreach (var prop in likes)
            {
                if (prop.UserId == user.UserId)
                    alreadyLiked = true;
            }
            if (!alreadyLiked)
            {
                var newLike = new Like(user.UserId, post.PostId);
                var sqlTwo = $"INSERT INTO Likes (UserId, PostId) VALUES(@UserId, @PostId)";
                connection.Execute(sqlTwo, newLike);
                return post = GetPostById(newLike.PostId);
            }
            var sqlThree = $"DELETE FROM Likes WHERE UserId = @UserId";
            connection.Execute(sqlThree, user);
            return post = GetPostById(postId);
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
        public Post UpdateContent(int postId, PostDto postDto)
        {
            var post = new Post(postId, postDto);
            if (!CorrectUser(postId, postDto.UserId))
            {
                throw new NotCorrectUser();
            }
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = $"UPDATE Post SET Content = @Content, LastDate = DATETIME('now') WHERE PostId = @PostId";
                connection.Execute(sql, post);
            }
            return _ = GetPostById(postId);
        }
    }
}
