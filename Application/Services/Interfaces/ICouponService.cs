using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface ICouponService
    {
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task ApplyCouponToClothingItemAsync(Guid clothingItemId, Guid couponCodeId);
        Task<IEnumerable<CouponDto>> GetAllCouponsAsync();
    }
}