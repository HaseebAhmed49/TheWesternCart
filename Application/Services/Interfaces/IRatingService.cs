using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IRatingService
    {
        Task AddRatingAsync(RatingDto rating);
        Task<double?> GetAverageRatingAsync(Guid clothingItemId);
        Task<RatingDto?> GetUserRatingAsync(string userId, Guid clothingItemId);
    }
}