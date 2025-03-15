using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Coupon>> GetAllCouponsAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task CreateCouponAsync(Coupon coupon)
        {
            var _coupon = new Coupon
            {
                Code = coupon.Code,
                DiscountPercentage = coupon.DiscountPercentage,
                ExpiryDate = coupon.ExpiryDate,
                IsActive = coupon.IsActive
            };

            await _context.Coupons.AddAsync(_coupon);
            await _context.SaveChangesAsync();
        }        
    }
}