using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface ILikeDislikeService
    {
        Task AddLikeDislikeAsync(LikeDislikeDto likeDislikeDto);
        Task RemoveLikeDislikeAsync(Guid likeDislikeId);
        Task<IEnumerable<LikeDislikeDto>> GetLikesDislikesByUserIdAsync(string userId);
        Task<IEnumerable<LikeDislikeDto>> GetLikesDislikesByCommentIdAsync(Guid commentId);

        Task<int> CountLikesAsync(Guid commentId);
        Task<int> CountDislikesAsync(Guid commentId);
    }
}