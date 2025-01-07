using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class LikeDislike : BaseEntity
    {
        public bool IsLike { get; set; }
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}