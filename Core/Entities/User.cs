using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities.Enums;
using Core.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }    public ShippingAddress Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; } 
        public virtual ICollection<FavouriteItem> FavoriteItems { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<LikeDislike> LikesDislikes { get; set; }
        public virtual ICollection<WishList> Wishlists { get; set; }
    }
}