using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IFavouriteRepository : IGenericRepository<FavouriteItem>
    {
        Task<IEnumerable<FavouriteItem>> GetFavoritesByUserIdAsync(string userId);
        Task<bool> IsFavoriteAsync(Guid clothingItemId, string userId);
        Task<FavouriteItem> GetByClothingItemIdAndUserId(Guid clothingItemId, string userId);
    }
}