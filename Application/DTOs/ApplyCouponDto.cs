using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ApplyCouponDto
    {
        public Guid ClothingItemId { get; set; }
        public string CouponCode { get; set; }
    }
}