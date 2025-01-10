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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IQueryable<Comment> GetCommentsForClothingItem(Guid clothingItemId)
        {
            return _context.Comments.Where(c => c.ClothingItemId == clothingItemId);
        }
        public async Task<IEnumerable<Comment>> GetCommentsForClothingItemIdAsync(Guid clothingItemId)
        {
            return await _context.Comments
                .Where(c => c.ClothingItemId == clothingItemId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(string userId)
        {
            return await _context.Comments
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }        
    }
}