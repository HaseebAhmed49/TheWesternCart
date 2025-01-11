using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> FindByEmailFromClaims(object ob);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<bool> CheckUserNameExistsAsync(string userName);
        Task<bool> CheckEmailExistsAsync(string email);
        Task<bool> ConfirmEmailAsync(string userName, string token);
        Task<string> GenerateEmailConfirmationTokenAsync(string userName);
        Task<bool> ResetPasswordAsync(string userName, string token, string newPassword);
        Task<string> GeneratePasswordResetTokenAsync(string userName);
        Task<bool> ChangePasswordAsync(string userName, string currentPassword, string newPassword);
    }
}