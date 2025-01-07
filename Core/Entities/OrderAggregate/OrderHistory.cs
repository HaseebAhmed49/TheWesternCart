using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities.Enums;

namespace Core.Entities.OrderAggregate
{
    public class OrderHistory : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
        public ICollection<OrderItemHistory> OrderItems { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}