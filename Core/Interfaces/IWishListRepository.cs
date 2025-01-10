using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IWishListRepository : IGenericRepository<WishList>
    {
        Task<IReadOnlyList<WishList>> GetWishListsByUserIdAsync(string userId);
        Task<WishList?> GetWishListByNameAsync(string userId, string name);
    }
}
