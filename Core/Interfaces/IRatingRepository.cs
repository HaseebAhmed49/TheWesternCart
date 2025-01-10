using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task AddRatingToClothingItemAsync(Guid clothingItemId, Rating rating);
        Task<double?> GetAverageRatingByClothingItemIdAsync(Guid clothingItemId);
        Task UpdateRatingAsync(string userId, Guid clothingItemId, int value);
    }
}