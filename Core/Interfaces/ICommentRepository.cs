using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task AddCommentToClothingItemAsync(Comment comment);
        Task RemoveCommentAsync(Comment comment);
        IQueryable<Comment> GetCommentsForClothingItem(Guid clothingItemId);
        Task<IEnumerable<Comment>> GetCommentsForClothingItemIdAsync(Guid clothingItemId);
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(string userId);
        
    }
}