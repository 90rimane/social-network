using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class User
    {
        private int _id = -1;
        public int Id
        {
            get { return _id; }
            set { if (_id == -1) _id = value; }
        }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserPass { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
