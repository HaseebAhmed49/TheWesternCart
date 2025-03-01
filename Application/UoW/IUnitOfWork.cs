using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GenericRepository<T>()
            where T : BaseEntity;
        IClothingItemRepository ClothingItemRepository { get; }
        ICommentRepository CommentRepository { get; }
        IFavouriteItemRepository FavoriteItemRepository { get; }
        ILikeDislikeRepository LikeDislikeRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IRatingRepository RatingRepository { get; }
        IWishListRepository WishListRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IOrderHistoryRepository OrderHistoryRepository { get; }
        IUserRepository UserRepository { get; }
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<AppRole> RoleManager { get; }
        Task<int> SaveAsync();
    }
}
