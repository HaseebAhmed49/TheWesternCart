using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface ICouponService
    {
        Task<CouponDto> CreateCouponAsync(CouponDto couponDto);
        Task ApplyCouponToClothingItemAsync(Guid clothingItemId, string couponCode);
    }
}