using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Interfaces;
using Application.UoW;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Specifications;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IBasketService basketService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;   
            
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, Guid deliveryMethodId, string basketId,
            AddressAggregate shippingAddress)
        {
            var basket = await _basketService.GetBasketAsync(basketId);
            if(basket == null)
            {
                throw new NotFoundException($"Basket with ID '{basketId}' not found.");
            }
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.GenericRepository<ClothingItem>().GetByIdAsync(item.Id);
                if (productItem == null)
                {
                    throw new NotFoundException($"Product item with ID '{item.Id}' not found.");
                }
                var itemOrdered = new ClothingItemOrdered(productItem.Id, productItem.Name, productItem.ClothingItemPhotos);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            var deliveryMethod = await _unitOfWork.GenericRepository<DelieveryMethod>().GetByIdAsync(deliveryMethodId);
                if (deliveryMethod == null)
            {
                throw new NotFoundException($"Delivery method with ID '{deliveryMethodId}' not found.");
            }
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            var spec = new OrderByPaymentIntentIdSpecification(basket.PaymentIntentId);
            var order = await _unitOfWork.GenericRepository<Order>().GetEntityWithSpec(spec);
            if (order != null)
            {
                order.ShipToAddress = shippingAddress;
                order.DeliveryMethod = deliveryMethod;
                order.Subtotal = subtotal;
                _unitOfWork.GenericRepository<Order>().Update(order);
            }
            else
            {
                order = new Order(items, buyerEmail, shippingAddress, deliveryMethod,
                    subtotal, basket.PaymentIntentId);
                _unitOfWork.GenericRepository<Order>().Add(order);
            }
            var result = await _unitOfWork.SaveAsync();
            if (result <= 0)
            {
                throw new InternalServerException("Failed to save the order.");
            }  
            return order;
        }
        public async Task<IReadOnlyList<DelieveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.GenericRepository<DelieveryMethod>().ListAllAsync();
        }
        public async Task<Order> GetOrderByIdAsync(Guid id, string buyerEmail)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(id, buyerEmail);
            var order = await _unitOfWork.GenericRepository<Order>().GetEntityWithSpec(spec);

            if (order == null)
            {
                throw new NotFoundException($"Order with ID '{id}' not found.");
            }
            return order;
        }
        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(buyerEmail);
            return await _unitOfWork.GenericRepository<Order>().ListAsync(spec);
        }
    }
}