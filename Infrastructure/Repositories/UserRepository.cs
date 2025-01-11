using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.UserName)
                .Include(u => u.Address)
                .Include(u => u.Orders)
                .Include(u => u.OrderHistories)
                .Include(u => u.FavoriteItems)
                .Include(u => u.Ratings)
                .Include(u => u.Comments)
                .Include(u => u.Notifications)
                .Include(u => u.LikesDislikes)
                .Include(u => u.Wishlists)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.UserName)
                .Include(u => u.Address)
                .Include(u => u.Orders)
                .Include(u => u.OrderHistories)
                .Include(u => u.FavoriteItems)
                .Include(u => u.Ratings)
                .Include(u => u.Comments)
                .Include(u => u.Notifications)
                .Include(u => u.LikesDislikes)
                .Include(u => u.Wishlists)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.UserName)
                .Include(u => u.Address)
                .Include(u => u.Orders)
                .Include(u => u.OrderHistories)
                .Include(u => u.FavoriteItems)
                .Include(u => u.Ratings)
                .Include(u => u.Comments)
                .Include(u => u.Notifications)
                .Include(u => u.LikesDislikes)
                .Include(u => u.Wishlists)
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }
        public async Task<IReadOnlyList<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.UserName)
                .Include(u => u.Address)
                .Include(u => u.Orders)
                .Include(u => u.OrderHistories)
                .Include(u => u.FavoriteItems)
                .Include(u => u.Ratings)
                .Include(u => u.Comments)
                .Include(u => u.Notifications)
                .Include(u => u.LikesDislikes)
                .Include(u => u.Wishlists)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(AppUserRole role)
        {
            return await _context.Users
                .Where(u => u.UserRoles.Any(ur => ur.RoleId == role.RoleId))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.UserName)
                .Include(u => u.Address)
                .Include(u => u.Orders)
                .Include(u => u.OrderHistories)
                .Include(u => u.FavoriteItems)
                .Include(u => u.Ratings)
                .Include(u => u.Comments)
                .Include(u => u.Notifications)
                .Include(u => u.LikesDislikes)
                .Include(u => u.Wishlists)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<User>> SearchUsersByNameAsync(string name)
        {
            return await _context.Users
                .Where(u => u.UserName.Contains(name))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.Address)
                .Include(u => u.Orders)
                .Include(u => u.OrderHistories)
                .Include(u => u.FavoriteItems)
                .Include(u => u.Ratings)
                .Include(u => u.Comments)
                .Include(u => u.Notifications)
                .Include(u => u.LikesDislikes)
                .Include(u => u.Wishlists)
                .ToListAsync();
        }
        
    }
}