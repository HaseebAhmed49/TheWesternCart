using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public Guid DeliveryMethodId { get; set; }
        public AddressDto ShipToAddress { get; set; }
    }
}