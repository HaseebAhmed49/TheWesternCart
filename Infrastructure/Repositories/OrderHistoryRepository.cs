using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderHistoryRepository : GenericRepository<OrderHistory>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderHistory>> GetOrderHistoryByUserIdAsync(string userId)
        {
            return await _context.OrderHistories
                .Include(f => f.OrderItems)
                .Include(f => f.User)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
        
        public async Task<OrderHistory> GetByIdAsync(Guid id)
        {
            return await _context.OrderHistories
                .Include(f => f.OrderItems)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IReadOnlyList<OrderHistory>> ListAllAsync()
        {
            return await _context.OrderHistories
                .Include(f => f.OrderItems)
                .ToListAsync();
        }
    }
}