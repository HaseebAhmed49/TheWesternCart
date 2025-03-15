using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICouponRepository : IGenericRepository<Coupon>
    {
        Task<IReadOnlyList<Coupon>> GetAllCouponsAsync();
        Task CreateCouponAsync(Coupon coupon);
        
    }
}