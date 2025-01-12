using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using CloudinaryDotNet.Actions;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByUsernameAsync(string userName);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<UserDto> GetUserByIdAsync(string id);
        Task<UserPhotoDto> AddPhotoByUser(ImageUploadResult result, string userName);
        Task SetMainUserPhotoByUser(Guid userPhotoId, string userName);
        Task DeleteUserPhotoByUser(Guid userPhotoId, string userName);
    }
}