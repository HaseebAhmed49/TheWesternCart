using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    public class CouponController : BaseApiController
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost]
        public async Task<ActionResult> CreateCoupon(CreateCouponDto couponDto)
        {
            try
            {
                await _couponService.CreateCouponAsync(couponDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("apply")]
        public async Task<ActionResult> ApplyCouponToClothingItem(ApplyCouponDto applyCouponDto)
        {
            try
            {
                await _couponService.ApplyCouponToClothingItemAsync(applyCouponDto.ClothingItemId,
                    applyCouponDto.CouponCodeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<CouponDto>>> GetAllCoupons()
        {
            try
            {
                var clothingItems = await _couponService.GetAllCouponsAsync();
                return Ok(clothingItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}