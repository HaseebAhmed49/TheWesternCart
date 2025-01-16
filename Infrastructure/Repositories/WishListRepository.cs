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
    public class WishListRepository : GenericRepository<WishList>, IWishListRepository
    {
        public WishListRepository(ApplicationDbContext context)
            : base(context) { }

        public async Task<IReadOnlyList<WishList>> GetWishListsByUserIdAsync(string userId)
        {
            return await _context
                .Wishlists.Where(w => w.UserId == userId)
                .Include(w => w.Items)
                .ToListAsync();
        }

        public async Task<WishList?> GetWishListByNameAsync(string userId, string name)
        {
            return await _context
                .Wishlists.Include(w => w.Items)
                .FirstOrDefaultAsync(w => w.UserId == userId && w.Name == name);
        }

        public async Task<IReadOnlyList<WishList>> GetWishlistsByClothingItemIdAsync(Guid clothingItemId)
        {
            return await _context.Wishlists
                .Where(w => w.Items.Any(i => i.ClothingItemId == clothingItemId))
                .Include(w => w.Items)
                .ToListAsync();
        }
    }
}
