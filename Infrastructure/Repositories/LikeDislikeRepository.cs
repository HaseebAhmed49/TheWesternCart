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
    public class LikeDislikeRepository : GenericRepository<LikeDislike>, ILikeDislikeRepository
    {
        public LikeDislikeRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<LikeDislike>> GetLikesDislikesByUserIdAsync(string userId)
        {
            return await _context.LikesDislikes
                .Include(ld => ld.Comment)
                .Where(ld => ld.UserId == userId)
                .ToListAsync();
        }
        public async Task<IEnumerable<LikeDislike>> GetLikesDislikesByCommentIdAsync(Guid commentId)
        {
            return await _context.LikesDislikes
                .Where(ld => ld.CommentId == commentId)
                .ToListAsync();    
        }        
    }
}