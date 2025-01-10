using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IFavouriteItemService
    {
        Task AddFavoriteAsync(Guid clothingItemId, string userId);
        Task RemoveFavoriteAsync(Guid clothingItemId, string userId);
        Task<IEnumerable<FavouriteItemDto>> GetFavoritesByUserIdAsync(string userId);
        Task<bool> IsFavoriteAsync(Guid clothingItemId, string userId);
    }
}