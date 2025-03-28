using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Enums;

namespace Core.Interfaces
{
    public interface IClothingItemRepository
    {
        Task<ClothingItem> GetClothingByIdAsync(Guid id);
        Task<IReadOnlyList<ClothingItem>> GetClothingAsync();
        Task<IReadOnlyList<ClothingBrand>> GetClothingBrandsAsync();
        Task<IReadOnlyList<ClothingItem>> GetClothingByGenderAsync(Gender gender);
        Task<IReadOnlyList<ClothingItem>> GetClothingBySizeAsync(Size size);
        Task<IReadOnlyList<ClothingItem>> GetClothingByCategoryAsync(Category category);
        Task<IReadOnlyList<ClothingItem>> GetClothingByFiltersAsync(Gender? gender = null, Size? size = null,
            Category? category = null);

        Task<IReadOnlyList<ClothingItem>> GetAllClothingItemsAsync();
    }
}