using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;

namespace Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail, Guid delieveryMethod, string basketId,
            AddressAggregate shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(Guid id, string buyerEmail);
        Task<IReadOnlyList<DelieveryMethod>> GetDeliveryMethodsAsync();
    }
}