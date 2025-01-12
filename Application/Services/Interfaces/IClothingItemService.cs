using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using CloudinaryDotNet.Actions;

namespace Application.Services.Interfaces
{
    public interface IClothingItemService
    {
        Task<ClothingItemPhotoDto> AddPhotoByClothingItem(ImageUploadResult result, Guid clothingItemId);
        Task SetMainClothingItemPhotoByClothingItem(Guid clothingItemPhotoId, Guid clothingItemId);
        Task DeleteClothingItemPhotoByClothingItem(Guid clothingItemPhotoId, Guid clothingItemId);
    }
}