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
        public async Task<ActionResult<IReadOnlyList<ClothingBrand>>> GetClothingBrandS()
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
    }
}