using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using API.Helpers;
using Application.DTOs;
using Application.Helpers;
using Application.Services.Interfaces;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class ClothingController : BaseApiController
    {
        private readonly IClothingItemService _clothingItemService;
        public ClothingController(IClothingItemService clothingItemService)
        {
            _clothingItemService = clothingItemService;
        }
        [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClothingItemDto>> GetClothingItem(Guid id)
        {
            try
            {
                return Ok(await _clothingItemService.GetClothingItemById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ClothingItemDto>>> GetClothingItems(
            [FromQuery] ClothingSpecParams clothingSpecParams)
        {
            try
            {
                return Ok(await _clothingItemService.GetClothingItems(clothingSpecParams));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Cached(600)]
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ClothingBrandDto>>> GetClothingBrandS()
        {
            try
            {
                return Ok(await _clothingItemService.GetClothingBrands());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("brands")]
        public async Task<ActionResult> AddClothingBrandAsync([FromBody] ClothingBrandDto clothingBrandDto)
        {
            try
            {
                await _clothingItemService.AddClothingBrandAsync(clothingBrandDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("items")]
        public async Task<ActionResult> AddClothingItemAsync([FromBody] ClothingItemDto clothingItemDto)
        {
            try
            {
                await _clothingItemService.AddClothingItemAsync(clothingItemDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<ClothingItemDto>>> GetAllClothingItems()
        {
            try
            {
                var clothingItems = await _clothingItemService.GetAllClothingItemsAsync();
                return Ok(clothingItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}