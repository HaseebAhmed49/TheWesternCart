using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPhotoRepository
    {
        Task<UserPhoto> GetUserPhotoByIdAsync(Guid userPhotoId);
        Task<ClothingItemPhoto> GetClothingItemPhotoByIdAsync(Guid clothingItemPhotoId);
        
        Task<UserPhoto> GetUserPhotoByIdAndUserNameAsync(Guid userPhotoId, string appUserName);
        Task<ClothingItemPhoto> GetClothingItemByIdAndClothingItemIdAsync(Guid clothingItemPhotoId, Guid clothingItemId);
        
        void RemoveUserPhoto(UserPhoto photo);
        void RemoveClothingItemPhoto(ClothingItemPhoto photo);
    }
}