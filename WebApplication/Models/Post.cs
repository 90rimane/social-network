using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
        public class Post
    {
        private int _id = -1;
        public Post()
        {
            PostDate = DateTime.Now;
        }

        public int Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime PostDate { get; }

        public IList<Post> GetPosts()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var posts = connection.Query<Post>("SELECT * FROM Post");
                return posts.ToList();
            }
        }
        public Post GetPostById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Post WHERE Post.Id = @Id";
                return connection.QuerySingle<Post>(sql, new { Id = id });
            }
        }
        public IList<Post> GetPostsByThread(Thread thread)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "SELECT p.*, u.* FROM Post AS p " +
                "JOIN User AS u ON (p.UserId = u.Id) " +
                "JOIN Thread ON (p.ThreadId = Thread.Id) " +
                "WHERE ThreadId = @Id; ";
                var posts = connection.Query<Post, User, Post>(sql, (post, user) =>
                {
                    post.User = user;
                    return post;
                }, thread);
                return posts.ToList();
            }
        }
        public void CreatePost(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO Post (ThreadId, Content, UserId, PostDate) " +
                "VALUES (@ThreadId, @Content, @UserId, @PostDate); " +
                "SELECT last_insert_rowid();";
                var id = connection.Query<int>(sql, post);
                post.Id = id.First();
            }
        }
        public void UpdatePost(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "UPDATE Post SET Content = @Content WHERE Id = @Id;";
                connection.Execute(sql, post);
            }
        }
        public void DeletePost(Post post)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "DELETE FROM Post WHERE Id = @Id;";
                connection.Execute(sql, post);
            }
        }
    }
}
