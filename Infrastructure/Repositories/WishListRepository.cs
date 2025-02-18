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

        public async Task<WishList> CreateNewWishListAsync(string userId, string wishlistName)
        {
            var wishlist = new WishList
            {
                UserId = userId,
                Name = wishlistName,
                Items = new List<WishListItem>(),
                CreatedAt = DateTime.Now,
            };
            await _context.Wishlists.AddAsync(wishlist);
            await _context.SaveChangesAsync();
            return wishlist;
        }
        public async Task RemoveWishListAsync(WishList wishlist)
        {
            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<WishList>> GetWishListsByUserIdAsync(string userId)
        {
            return await _context
                .Wishlists.Where(w => w.UserId == userId)
                .Include(u => u.User)
                .Include(w => w.Items)
                .ThenInclude(i => i.ClothingItem)
                .ThenInclude(ci => ci.ClothingItemPhotos)
                .ToListAsync();
        }

        public async Task<WishList?> GetWishListByNameAsync(string userId, string wishlistName)
        {
            return await _context.Wishlists
                .Include(w => w.Items)
                .Include(u => u.User)
                .FirstOrDefaultAsync(w => w.UserId == userId && w.Name == wishlistName);
        }

        public async Task<IReadOnlyList<WishList>> GetWishListsByClothingItemIdAsync(Guid clothingItemId)
        {
            return await _context.Wishlists
                .Where(w => w.Items.Any(i => i.ClothingItemId == clothingItemId))
                .Include(w => w.Items)
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<WishListItem> AddItemToWishListAsync(WishList wishlist, Guid clothingItemId)
        {
            var wishlistItem = new WishListItem
            {
                WishListId = wishlist.Id,
                ClothingItemId = clothingItemId
            };
            wishlist.Items.Add(wishlistItem);
            await _context.SaveChangesAsync();
            await _context.Entry(wishlistItem)
                .Reference(wi => wi.ClothingItem)
                .Query()
                .Include(ci => ci.ClothingItemPhotos)
                .LoadAsync();
            return wishlistItem;
        }
        public async Task<bool> RemoveItemFromWishListAsync(WishList wishlist, Guid itemId)
        {
            var item = wishlist.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                return false;
            }
            wishlist.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<WishList?> GetByIdAsync(Guid id)
        {
            return await _context.Wishlists
                .Include(w => w.Items)
                .ThenInclude(i => i.ClothingItem)
                .ThenInclude(ci => ci.ClothingItemPhotos)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
