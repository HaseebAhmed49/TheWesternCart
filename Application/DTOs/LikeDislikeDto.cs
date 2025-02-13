using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LikeDislikeDto
    {
        public bool IsLike { get; set; }
        public Guid CommentId { get; set; }
        public string UserDtoId { get; set; }
        public UserDto UserDto { get; set; }
    }
}