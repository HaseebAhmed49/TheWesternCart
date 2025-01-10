using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Enums;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(string userId);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByUserName(string userName);
        Task<IReadOnlyList<User>> GetAllUsersAsync();
        Task<IReadOnlyList<User>> GetUsersByRoleAsync(AppUserRole role);
        Task<IReadOnlyList<User>> SearchUsersByNameAsync(string name);
    }
}