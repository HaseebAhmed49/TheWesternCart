using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;
        IClothingItemRepository ClothingItemRepository { get; }        
        ICommentRepository CommentRepository { get; }
        // IFavouriteItemRepository FavoriteItemRepository { get; }
        ILikeDislikeRepository LikeDislikeRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IRatingRepository RatingRepository { get; }
        IWishListRepository WishlistRepository { get; }
        IUserRepository UserRepository { get; }
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        Task<int> SaveAsync();        
    }
}