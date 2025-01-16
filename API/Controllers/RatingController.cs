using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    public class RatingController : BaseApiController
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        [HttpPost]
        public async Task<ActionResult> AddRating(RatingDto ratingDto)
        {
            try
            {
                await _ratingService.AddRatingAsync(ratingDto.ClothingItemId, ratingDto);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        [HttpGet("clothing/clothingItemId/average")]
        public async Task<ActionResult<double?>> GetAverageRating(Guid clothingItemId)
        {
            try
            {
                var averageRating = await _ratingService.GetAverageRatingAsync(clothingItemId);
                return Ok(averageRating);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRating(RatingDto ratingDto)
        {
            try
            {
                await _ratingService.UpdateRatingAsync(ratingDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
    }
}