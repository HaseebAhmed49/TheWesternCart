using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Application.UoW;
using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<UserDto> FindByEmailFromClaims(object ob)
        {
            var claimsPrincipal = ob as ClaimsPrincipal;
            var email = claimsPrincipal?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
            {
                throw new ForbiddenException("Invalid claims principal");
            }
            var user = await _unitOfWork.UserManager.Users
            .Include(u => u.UserPhotos)
            .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = await _tokenService.CreateToken(user);
            return userDto;
        }
        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await CheckEmailExistsAsync(registerDto.Email))
                throw new UnauthorizedException("Email is taken");
            var user = _mapper.Map<User>(registerDto);
            
            string baseUsername = $"{registerDto.FirstName}{registerDto.LastName}";
            string uniqueUsername;
            do
            {
                uniqueUsername = $"{baseUsername}{new Random().Next(100, 999)}";
            } while (await CheckUserNameExistsAsync(uniqueUsername));
            user.UserName = uniqueUsername.ToLower();
            user.Email = registerDto.Email.ToLower();
            user.Created = DateTime.UtcNow;
            user.LastActive = DateTime.UtcNow;
            var result = await _unitOfWork.UserManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) 
                throw new UnauthorizedException("Error!");
            var roleResult = await _unitOfWork.UserManager.AddToRoleAsync(user, "Buyer");
            if (!roleResult.Succeeded) 
                throw new UnauthorizedException("Error!");
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = await _tokenService.CreateToken(user);
            return userDto;
        }
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.UserManager.Users
                .Include(u => u.UserPhotos)
                .SingleOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null) 
                throw new UnauthorizedException("Invalid email");
            var result = await _unitOfWork.SignInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) 
                throw new UnauthorizedException("Invalid password");
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = await _tokenService.CreateToken(user);
            return userDto;
        }
        
        public async Task<bool> CheckUserNameExistsAsync(string userName)
        {
            if (userName == null) throw new NotFoundException("UserName doesn't exist");
            return await _unitOfWork.UserManager.Users.AnyAsync(x => x.UserName == userName.ToLower());
        }
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            if (email == null) throw new NotFoundException("Email doesn't exist");
            return await _unitOfWork.UserManager.FindByEmailAsync(email) != null;
        }
        public async Task<bool> ConfirmEmailAsync(string userName, string token)
        {
            var user = await _unitOfWork.UserManager.FindByNameAsync(userName);
            if (user == null) throw new NotFoundException("User doesn't exist");
            var result = await _unitOfWork.UserManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }
        public async Task<string> GenerateEmailConfirmationTokenAsync(string userName)
        {
            var user = await _unitOfWork.UserManager.FindByNameAsync(userName);
            if (user == null) throw new NotFoundException("User doesn't exist");
            return await _unitOfWork.UserManager.GenerateEmailConfirmationTokenAsync(user);
        }
        public async Task<bool> ResetPasswordAsync(string userName, string token, string newPassword)
        {
            var user = await _unitOfWork.UserManager.FindByNameAsync(userName);
            if (user == null) throw new NotFoundException("User doesn't exist");
            var result = await _unitOfWork.UserManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
        public async Task<string> GeneratePasswordResetTokenAsync(string userName)
        {
            var user = await _unitOfWork.UserManager.FindByNameAsync(userName);
            if (user == null) throw new NotFoundException("User doesn't exist");
            return await _unitOfWork.UserManager.GeneratePasswordResetTokenAsync(user);
        }
        public async Task<bool> ChangePasswordAsync(string userName, string currentPassword, string newPassword)
        {
            var user = await _unitOfWork.UserManager.FindByNameAsync(userName);
            if (user == null) throw new NotFoundException("User doesn't exist");
            var result = await _unitOfWork.UserManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return result.Succeeded;
        }
        
    }
}