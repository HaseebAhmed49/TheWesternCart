using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        Task CreateOrderHistoryAsync(OrderHistoryDto order, string userId);
        Task<IReadOnlyList<OrderHistoryToReturnDto>> GetOrderHistoriesByUserIdAsync(string userId);
        Task<OrderHistoryToReturnDto> GetOrderHistoryByIdAsync(Guid id);
        Task<IReadOnlyList<OrderHistoryToReturnDto>> GatAllOrderHistoriesAsync();
    }
}