using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateCouponDto
    {
        public int DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}