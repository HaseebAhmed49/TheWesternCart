using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities.OrderAggregate
{
    public class OrderItemHistory : BaseEntity
    {
        public Guid OrderHistoryId { get; set; }
        public Guid ClothingItemId { get; set; }
        public string ClothingItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
    }
}