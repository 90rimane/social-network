using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Like
    {
        public Like()
        {
        }
        public Like(int userId, int postId)
        {
            UserId = userId;
            PostId = postId;
        }
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
