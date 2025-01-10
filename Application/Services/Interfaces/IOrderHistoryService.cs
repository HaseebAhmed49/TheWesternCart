using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        Task<OrderHistoryDto> CreateOrderHistoryAsync(OrderDto order);
        Task<IReadOnlyList<OrderHistoryDto>> GetOrderHistoriesForUserAsync(string userId);
        Task<OrderHistoryDto> GetOrderHistoryByIdAsync(Guid id);
    }
}