using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Helpers;
using CloudinaryDotNet.Actions;
using Core.Entities;
using Core.Specifications;

namespace Application.Services.Interfaces
{
    public interface IClothingItemService
    {
        Task<ClothingItemDto> GetClothingItemById(Guid clothingItemId);
        Task<Pagination<ClothingItemDto>> GetClothingItems(ClothingSpecParams clothingSpecParams);
        Task<IReadOnlyList<ClothingBrand>> GetClothingBrands();
        Task<ClothingItemPhotoDto> AddPhotoByClothingItem(ImageUploadResult result, Guid clothingItemId);
        Task SetMainClothingItemPhotoByClothingItem(Guid clothingItemPhotoId, Guid clothingItemId);
        Task DeleteClothingItemPhotoByClothingItem(Guid clothingItemPhotoId, Guid clothingItemId);
    }
}