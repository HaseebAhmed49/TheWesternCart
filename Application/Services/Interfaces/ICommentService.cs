using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentAsync(CommentDto commentDto);
        Task RemoveCommentAsync(Guid commentId);
        Task<IEnumerable<CommentDto>> GetCommentsForClothingItemAsync(Guid clothingItemId);
        Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(string userId);
    }
}