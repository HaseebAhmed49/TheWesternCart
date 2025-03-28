using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities.Enums;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {
            
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, AddressAggregate shipToAddress,
            DelieveryMethod deliveryMethod, decimal subtotal, string paymentIntentId, Coupon coupon = null)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;
            Coupon = coupon;
        }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public AddressAggregate ShipToAddress { get; set; }
        public DelieveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public Guid? CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            decimal discount = 0;
            if (Coupon != null && Coupon.IsActive && Coupon.ExpiryDate > DateTime.Now)
            {
                discount = Subtotal * Coupon.DiscountPercentage / 100;
            }
            decimal deliveryPrice = DeliveryMethod?.Price ?? 0;
            return Subtotal + deliveryPrice - discount;
        }
    }
}