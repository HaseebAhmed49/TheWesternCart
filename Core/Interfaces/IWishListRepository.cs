using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IWishListRepository : IGenericRepository<WishList>
    {
        Task<IReadOnlyList<WishList>> GetWishlistsByUserIdAsync(Guid userId);
        Task<WishList?> GetWishlistByNameAsync(Guid userId, string name);
            
    }
}