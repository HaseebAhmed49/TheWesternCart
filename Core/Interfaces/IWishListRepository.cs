using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IWishListRepository : IGenericRepository<WishList>
    {
        Task<IReadOnlyList<WishList>> GetWishlistsByUserIdAsync(string userId);
        Task<WishList?> GetWishlistByNameAsync(string userId, string name);            
    }
}