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

        public async Task AddCommentToClothingItemAsync(Comment comment)
        {
            var _comment = new Comment
            {
                UserId = comment.UserId,
                ClothingItem = comment.ClothingItem,
                ClothingItemId = comment.ClothingItemId,
                Text = comment.Text,
                CreatedAt = DateTime.Now
            };
            await _context.Comments.AddAsync(_comment);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCommentAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Comment> GetCommentsForClothingItem(Guid clothingItemId)
        {
            return _context.Comments.Where(c => c.ClothingItemId == clothingItemId);
        }
        
        public async Task<IEnumerable<Comment>> GetCommentsForClothingItemIdAsync(Guid clothingItemId)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Where(c => c.ClothingItemId == clothingItemId)
                .ToListAsync();
        }
        
         public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(string userId)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }        
    }
}