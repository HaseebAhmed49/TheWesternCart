using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IWishListRepository : IGenericRepository<WishList>
    {
        Task<WishList> CreateNewWishListAsync(string userId, string wishlistName);
        Task RemoveWishListAsync(WishList wishlist);
        Task<WishList?> GetWishListByNameAsync(string userId, string wishlistName);

        Task<IReadOnlyList<WishList>> GetWishListsByUserIdAsync(string userId);
        Task<IReadOnlyList<WishList>> GetWishListsByClothingItemIdAsync(Guid clothingItemId);
        Task<WishListItem> AddItemToWishListAsync(WishList wishlist, Guid clothingItemId);
        Task<bool> RemoveItemFromWishListAsync(WishList wishlist, Guid itemId);
    }
}
