using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LikeDislikeDto
    {
        public bool IsLike { get; set; }
        [Required]
        public Guid CommentId { get; set; }
        [Required]
        public string UserId { get; set; }
        
        public string Username { get; set; }    
    }
}