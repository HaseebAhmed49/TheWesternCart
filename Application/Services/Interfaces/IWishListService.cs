using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IWishListService
    {
        Task<IReadOnlyList<WishListDto>> GetWishListsByUserIdAsync(string userId);
        Task<WishListDto?> GetWishListByNameAsync(string userId, string name);
        Task<WishListDto> CreateWishListAsync(string userId, string name);
        Task<bool> DeleteWishListAsync(Guid wishlistId);
        Task<WishListItemDto> AddItemToWishListAsync(string userId, Guid clothingItemId, Guid? wishlistId = null);
        Task<bool> RemoveItemFromWishListAsync(Guid wishlistId, Guid itemId);
    }
}