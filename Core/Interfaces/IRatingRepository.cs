using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<IEnumerable<Rating>> GetRatingsByUserIdAsync(string userId);
        Task<IEnumerable<Rating>> GetRatingsByClothingItemIdAsync(Guid clothingItemId);
        Task<double?> GetAverageRatingByClothingItemIdAsync(Guid clothingItemId);
        Task AddRatingToClothingItemAsync(Rating rating);
        Task UpdateRatingAsync(string userId, Guid clothingItemId, int value);
        Task<Rating?> GetUserRatingAsync(string userId, Guid clothingItemId);
    }
}