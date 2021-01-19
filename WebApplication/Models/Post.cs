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
            return null;
        }
        public Post GetPostById(int id)
        {
            return null;
        }

        public void CreatePost(Post post)
        {

        }
        public void UpdatePost(Post post)
        {

        }
        public void DeletePost(Post post)
        {

        }
    }
}
