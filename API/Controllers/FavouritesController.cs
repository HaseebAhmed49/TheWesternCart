using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using API.Extensions;
using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    public class FavouritesController : BaseApiController
    {

        private readonly IFavouriteItemService _favoriteItemService;
        public FavouritesController(IFavouriteItemService favoriteItemService)
        {
            _favoriteItemService = favoriteItemService;
        }
        [HttpPost("{clothingItemId}")]
        public async Task<ActionResult> AddFavorite(Guid clothingItemId)
        {
            try
            {
                var userId = User.GetUserId();
                await _favoriteItemService.AddFavoriteAsync(clothingItemId, userId);
                return Ok();
            }
            catch (ConflictException ex)
            {
                return Conflict(new ApiResponse(409, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        [HttpDelete("{clothingItemId}")]
        public async Task<ActionResult> RemoveFavorite(Guid clothingItemId)
        {
            try
            {
                var userId = User.GetUserId();
                await _favoriteItemService.RemoveFavoriteAsync(clothingItemId, userId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse(404, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<FavouriteItemDto>>> GetFavoritesByUserId()
        {
            try
            {
                var userId = User.GetUserId();
                var favoriteItems = await _favoriteItemService.GetFavoritesByUserIdAsync(userId);
                return Ok(favoriteItems);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse(404, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        [HttpGet("{clothingItemId}/isFavorite")]
        public async Task<ActionResult<bool>> IsFavorite(Guid clothingItemId)
        {
            try
            {
                var userId = User.GetUserId();
                var isFavorite = await _favoriteItemService.IsFavoriteAsync(clothingItemId, userId);
                return Ok(isFavorite);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
    }
}