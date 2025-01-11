using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<UserPhotoDto> GetUserPhotoByIdAsync(Guid userPhotoId);
        Task<ClothingItemPhotoDto> GetClothingItemPhotoByIdAsync(Guid clothingItemPhotoId);
        
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task DeleteUserPhotoByIdAsync(Guid userPhotoId);
        Task DeleteClothingItemPhotoByIdAsync(Guid clothingItemPhotoId);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}