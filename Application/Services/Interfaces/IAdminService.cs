using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<object>> GetUsersWithRoles();
        Task<IEnumerable<string>> EditRoles(string userName, string roles);
        Task<IEnumerable<object>> GetRoles();
        Task<bool> AddRole(string roleName);
        Task<bool> DeleteRole(string roleName);        
        Task<OrderDto> EditUserOrderAsync(Guid orderId, OrderUpdateDto orderUpdateDto);
        Task<IReadOnlyList<OrderToReturnDto>> GetOrdersByUserEmailAsync(string buyerEmail);
    }
}