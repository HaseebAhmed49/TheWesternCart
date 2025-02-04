using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ClothingItemWithTypesAndBrandsSpecification : BaseSpecification<ClothingItem>
    {
            public ClothingItemWithTypesAndBrandsSpecification(Guid id)
            : base(x => x.Id == id)
            {
                AddInclude(x => x.ClothingItemPhotos);
                AddInclude(x => x.ClothingBrand);
            }
            public ClothingItemWithTypesAndBrandsSpecification(ClothingSpecParams clothingSpecParams)
            : base(x =>
                (string.IsNullOrEmpty(clothingSpecParams.Search) ||
                 x.Name.ToLower().Contains(clothingSpecParams.Search)) &&
                (!clothingSpecParams.ClothingBrandId.HasValue ||
                 x.ClothingBrandId == clothingSpecParams.ClothingBrandId) &&
                (!clothingSpecParams.Gender.HasValue || x.Gender == clothingSpecParams.Gender) &&
                (!clothingSpecParams.Size.HasValue || x.Size == clothingSpecParams.Size) &&
                (!clothingSpecParams.Category.HasValue || x.Category == clothingSpecParams.Category)
                )
            {
                AddInclude(x => x.ClothingItemPhotos);
                AddInclude(x => x.ClothingBrand);
                ApplyPaging(clothingSpecParams.PageSize * (clothingSpecParams.PageIndex - 1), clothingSpecParams.PageSize);
                if (!string.IsNullOrEmpty(clothingSpecParams.Sort))
                {
                    switch (clothingSpecParams.Sort)
                    {
                        case "priceAsc":
                            AddOrderBy(p => p.Price);
                            break;
                        case "priceDesc":
                            AddOrderByDescending(p => p.Price);
                            break;
                        default:
                            AddOrderBy(n => n.Name);
                            break;
                    }
                }
            }
    }
}