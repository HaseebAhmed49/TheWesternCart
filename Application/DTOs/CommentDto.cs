using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Username { get; set; }
        public Guid ClothingItemId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? TimeAgo { get; set; }
        public List<LikeDislikeDto>? LikesDislikes { get; set; }
    }
}