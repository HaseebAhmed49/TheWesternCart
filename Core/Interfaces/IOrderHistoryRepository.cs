using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public interface IOrderHistoryRepository : IGenericRepository<OrderHistory>
    {
        Task<IEnumerable<OrderHistory>> GetOrderHistoryByUserIdAsync(string userId);
        Task<OrderHistory> GetByIdAsync(Guid id);
        Task<IReadOnlyList<OrderHistory>> ListAllAsync();
        
    }
}