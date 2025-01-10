using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Enums;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClothingItemRepository : IClothingItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ClothingItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClothingItem> GetClothingByIdAsync(Guid id)
        {
            return await _context
                .ClothingItems.Include(c => c.ClothingBrand)
                .Include(c => c.Ratings)
                .Include(c => c.Comments)
                .Include(c => c.FavouriteItems)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IReadOnlyList<ClothingItem>> GetClothingAsync()
        {
            return await _context.ClothingItems.Include(c => c.ClothingBrand).ToListAsync();
        }

        public async Task<IReadOnlyList<ClothingBrand>> GetClothingBrandsAsync()
        {
            return await _context.ClothingBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ClothingItem>> GetClothingByGenderAsync(Gender gender)
        {
            return await _context
                .ClothingItems.Where(c => c.Gender == gender)
                .Include(c => c.ClothingBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ClothingItem>> GetClothingBySizeAsync(Size size)
        {
            return await _context
                .ClothingItems.Where(c => c.Size == size)
                .Include(c => c.ClothingBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ClothingItem>> GetClothingByCategoryAsync(Category category)
        {
            return await _context
                .ClothingItems.Where(c => c.Category == category)
                .Include(c => c.ClothingBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ClothingItem>> GetClothingByFiltersAsync(
            Gender? gender = null,
            Size? size = null,
            Category? category = null
        )
        {
            var query = _context.ClothingItems.AsQueryable();
            if (gender.HasValue)
            {
                query = query.Where(c => c.Gender == gender);
            }
            if (size.HasValue)
            {
                query = query.Where(c => c.Size == size);
            }
            if (category.HasValue)
            {
                query = query.Where(c => c.Category == category);
            }
            return await query.Include(c => c.ClothingBrand).ToListAsync();
        }
    }
}