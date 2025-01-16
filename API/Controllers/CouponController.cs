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
        public async Task<ActionResult<CouponDto>> CreateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {
                var createdCoupon = await _couponService.CreateCouponAsync(couponDto);
                return Ok(createdCoupon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("apply")]
        public async Task<ActionResult> ApplyCouponToClothingItem([FromBody] ApplyCouponDto applyCouponDto)
        {
            try
            {
                await _couponService.ApplyCouponToClothingItemAsync(applyCouponDto.ClothingItemId,
                    applyCouponDto.CouponCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}