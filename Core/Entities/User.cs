using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities.Enums;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public ICollection<FavouriteItem> FavouriteItems { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<LikeDislike> LikesDislikes { get; set; }
    }
}