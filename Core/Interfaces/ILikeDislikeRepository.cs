using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ILikeDislikeRepository : IGenericRepository<LikeDislike>
    {
        Task AddLikeToCommentAsync(LikeDislike likeDislike);
        Task<IEnumerable<LikeDislike>> GetLikesDislikesByUserIdAsync(string userId);
        Task<IEnumerable<LikeDislike>> GetLikesDislikesByCommentIdAsync(Guid commentId);        
        Task<int> CountLikesAsync(Guid commentId);
        Task<int> CountDislikesAsync(Guid commentId);
    }
}