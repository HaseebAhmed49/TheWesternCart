using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Interfaces;
using Application.UoW;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Specifications;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderHistoryService _orderHistoryService;
        private readonly IMapper _mapper;

        public OrderService(IBasketService basketService, IUnitOfWork unitOfWork, IOrderHistoryService orderHistoryService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;
            _orderHistoryService = orderHistoryService;
            _mapper = mapper;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, Guid deliveryMethodId, string basketId,
            AddressAggregate shippingAddress)
        {
            var basket = await _basketService.GetBasketAsync(basketId);
            if (basket == null)
            {
                throw new NotFoundException($"Basket with ID '{basketId}' not found.");
            }
            
            var userId = _unitOfWork.UserManager.Users.FirstOrDefault(u => u.Email == buyerEmail)?.Id;
            if (userId == null)
            {
                throw new NotFoundException($"User with email '{buyerEmail}' not found.");
            }

            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.GenericRepository<ClothingItem>().GetByIdAsync(item.Id);
                if (productItem == null)
                {
                    throw new NotFoundException($"Product item with ID '{item.Id}' not found.");
                }

                decimal discountPrice;
                if (productItem.Discount == null || productItem.Discount == 0)
                {
                    discountPrice = productItem.Price;
                }
                else
                {
                    discountPrice = productItem.Price - (productItem.Price * (productItem.Discount.Value / 100));
                }
                var itemOrdered = new ClothingItemOrdered(productItem.Id, productItem.Name, productItem.ClothingItemPhotos);
                var orderItem = new OrderItem(itemOrdered, discountPrice, item.Quantity);
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
                order.OrderItems = items;
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

            var orderHistoryDto = new OrderHistoryDto
            {
                OrderDate = order.OrderDate.DateTime,
                TotalAmount = order.GetTotal(),
                Status = order.Status.ToString(),
                ShippingAddress = order.ShipToAddress.AddressLine,
                OrderItems = order.OrderItems.Select(item => new OrderItemHistoryDto
                {
                    ClothingItemId = item.ItemOrdered.ClothingItemId,
                    ClothingItemName = item.ItemOrdered.ClothingItemName,
                    Quantity = item.Quantity,
                    PriceAtPurchase = item.Price
                }).ToList()
            };
            
            await _orderHistoryService.CreateOrderHistoryAsync(orderHistoryDto, userId);

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

        public async Task<OrderDto> EditUserOrderAsync(Guid orderId, OrderUpdateDto orderUpdateDto)
        {
            var order = await _unitOfWork.GenericRepository<Order>().GetByIdAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException($"Order with ID '{orderId}' not found.");
            }
            if (orderUpdateDto.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.GenericRepository<DelieveryMethod>()
                    .GetByIdAsync(orderUpdateDto.DeliveryMethodId.Value);
                if (deliveryMethod == null)
                {
                    throw new NotFoundException($"Delivery method with ID '{orderUpdateDto.DeliveryMethodId}' not found.");
                }
                order.DeliveryMethod = deliveryMethod;
            }
            order.ShipToAddress = _mapper.Map<AddressAggregate>(orderUpdateDto.ShipToAddress);
            var updatedOrderItems = new List<OrderItem>();
            foreach (var itemDto in orderUpdateDto.OrderItems)
            {
                var clothingItem = await _unitOfWork.GenericRepository<ClothingItem>().GetByIdAsync(itemDto.ClothingItemId);
                if (clothingItem == null)
                {
                    throw new NotFoundException($"Clothing item with ID '{itemDto.ClothingItemId}' not found.");
                }
                var itemOrdered = new ClothingItemOrdered(clothingItem.Id, clothingItem.Name, clothingItem.ClothingItemPhotos);
                var orderItem = new OrderItem(itemOrdered, clothingItem.Price, itemDto.Quantity);
                updatedOrderItems.Add(orderItem);
            }
            order.OrderItems = updatedOrderItems;
            order.Subtotal = updatedOrderItems.Sum(item => item.Price * item.Quantity);
            _unitOfWork.GenericRepository<Order>().Update(order);
            var result = await _unitOfWork.SaveAsync();
            if (result <= 0)
            {
                throw new InternalServerException("Failed to update the order.");
            }
            return _mapper.Map<OrderDto>(order);
        }
        
        public async Task<IReadOnlyList<OrderToReturnDto>> GetOrdersByUserEmailAsync(string buyerEmail)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(buyerEmail);
            var orders = await _unitOfWork.GenericRepository<Order>().ListAsync(spec);
            if (orders == null || !orders.Any())
            {
                throw new NotFoundException($"No orders found for user with email '{buyerEmail}'.");
            }
            var orderDtos = orders.Select(order => new OrderToReturnDto
            {
                Id = order.Id,
                BuyerEmail = order.BuyerEmail,
                OrderDate = order.OrderDate,
                ShipToAddress = order.ShipToAddress,
                DeliveryMethod = order.DeliveryMethod.ShortName,
                ShippingPrice = order.DeliveryMethod.Price,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    ClothingItemId = item.ItemOrdered.ClothingItemId,
                    ClothingItemName = item.ItemOrdered.ClothingItemName,
                    PictureUrl = item.ItemOrdered.MainPictureUrl,
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList(),
                Subtotal = order.Subtotal,
                Total = order.GetTotal(),
                Status = order.Status.ToString()
            }).ToList();
            return orderDtos;
        }
    }
}