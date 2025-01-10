using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderUpdateDto
    {
        public Guid OrderId { get; set; }
        public Guid? DeliveryMethodId { get; set; }
        public AddressDto ShipToAddress { get; set; }
        public List<OrderItemUpdateDto> OrderItems { get; set; }
        public string Status { get; set; }
        public decimal? Subtotal { get; set; }
    }
}