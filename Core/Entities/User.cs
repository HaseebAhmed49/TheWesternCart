using Core.Entities.Enums;
using Core.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public ShippingAddress Address { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
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