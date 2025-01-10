using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FavouriteItemRepository
        : GenericRepository<FavouriteItem>,
            IFavouriteItemRepository
    {
        public FavouriteItemRepository(ApplicationDbContext context)
            : base(context) { }

        public async Task<IEnumerable<FavouriteItem>> GetFavoritesByUserIdAsync(string userId)
        {
            return await _context
                .FavoriteItems.Include(f => f.ClothingItem)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> IsFavoriteAsync(Guid clothingItemId, string userId)
        {
            return await _context.FavoriteItems.AnyAsync(f =>
                f.ClothingItemId == clothingItemId && f.UserId == userId
            );
        }

        public async Task<FavouriteItem> GetByClothingItemIdAndUserId(
            Guid clothingItemId,
            string userId
        )
        {
            return await _context
                .FavoriteItems.Include(f => f.ClothingItem)
                .FirstOrDefaultAsync(f => f.ClothingItemId == clothingItemId && f.UserId == userId);
        }
    }
}
