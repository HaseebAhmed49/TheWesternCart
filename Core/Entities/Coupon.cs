using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}