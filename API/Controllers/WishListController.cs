using API.Controllers;
using API.Errors;
using API.Extensions;
using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class WishListController : BaseApiController
{
    private readonly IWishListService _wishlistService;

    public WishListController(IWishListService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    [HttpPost("{wishlistName}")]
    public async Task<ActionResult> CreateWishlist(string wishlistName)
    {
        try
        {
            var userId = User.GetUserId();
            await _wishlistService.CreateWishListAsync(userId, wishlistName);
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

    [HttpGet("user")]
    public async Task<ActionResult<IEnumerable<WishListDto>>> GetWishlistsByUserId()
    {
        try
        {
            var userId = User.GetUserId();
            var wishlists = await _wishlistService.GetWishListsByUserIdAsync(userId);
            return Ok(wishlists);
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

    [HttpGet("user/{userId}/name/{wishlistName}")]
    public async Task<ActionResult<WishListDto>> GetWishlistByName(string wishlistName)
    {
        try
        {
            var userId = User.GetUserId();
            var wishlist = await _wishlistService.GetWishListByNameAsync(userId, wishlistName);
            return Ok(wishlist);
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

    [HttpDelete("{wishlistId}")]
    public async Task<ActionResult> DeleteWishlist(Guid wishlistId)
    {
        try
        {
            await _wishlistService.DeleteWishListAsync(wishlistId);
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

    [HttpPost("{wishlistId}/items/{clothingItemId}")]
    public async Task<ActionResult<WishListItemDto>> AddItemToWishlist(Guid wishlistId, Guid clothingItemId)
    {
        try
        {
            var userId = User.GetUserId();
            var wishlistItem = await _wishlistService.AddItemToWishListAsync(userId, clothingItemId, wishlistId);
            return Ok(wishlistItem);
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

    [HttpDelete("{wishlistId}/items/{itemId}")]
    public async Task<ActionResult> RemoveItemFromWishlist(Guid wishlistId, Guid itemId)
    {
        try
        {
            await _wishlistService.RemoveItemFromWishListAsync(wishlistId, itemId);
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
}