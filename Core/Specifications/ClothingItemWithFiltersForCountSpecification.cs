using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ClothingItemWithFiltersForCountSpecification : BaseSpecification<ClothingItem>
    {
        public ClothingItemWithFiltersForCountSpecification(ClothingSpecParams clothingParams) 
            : base(x => 
                (string.IsNullOrEmpty(clothingParams.Search) || x.Name.ToLower().Contains(clothingParams.Search)) &&
                (!clothingParams.ClothingBrandId.HasValue || x.ClothingBrandId == clothingParams.ClothingBrandId) &&
                (!clothingParams.Gender.HasValue || x.Gender == clothingParams.Gender) &&
                (!clothingParams.Size.HasValue || x.Size == clothingParams.Size) &&
                (!clothingParams.Category.HasValue || x.Category == clothingParams.Category)
            )
        {
        }
    }        
}