using API.Errors;
using API.Extensions;
using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class WishListController : BaseApiController
    {
        private readonly IWishListService _wishListService;
        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<WishListDto>>> GetWishListsByUserId()
        {
            try
            {
                var userId = User.GetUserId();
                var wishLists = await _wishListService.GetWishListsByUserIdAsync(userId);
                return Ok(wishLists);
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
        [HttpGet("user/{userId}/name/{name}")]
        public async Task<ActionResult<WishListDto>> GetWishListByName(string name)
        {
            try
            {
                var userId = User.GetUserId();
                var wishList = await _wishListService.GetWishListByNameAsync(userId, name);
                return Ok(wishList);
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
        [HttpPost]
        public async Task<ActionResult<WishListDto>> CreateWishList(string userId, string name)
        {
            try
            {
                var wishList = await _wishListService.CreateWishListAsync(userId, name);
                return CreatedAtAction(nameof(GetWishListByName), new { userId, name }, wishList);
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
        [HttpDelete("{wishListId}")]
        public async Task<ActionResult> DeleteWishList(Guid wishListId)
        {
            try
            {
                await _wishListService.DeleteWishListAsync(wishListId);
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
        [HttpPost("{wishListId}/items")]
        public async Task<ActionResult<WishListItemDto>> AddItemToWishList(Guid wishListId, Guid clothingItemId)
        {
            try
            {
                var wishListItem = await _wishListService.AddItemToWishListAsync(wishListId, clothingItemId);
                return Ok(wishListItem);
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
        [HttpDelete("{wishListId}/items/{itemId}")]
        public async Task<ActionResult> RemoveItemFromWishList(Guid wishListId, Guid itemId)
        {
            try
            {
                await _wishListService.RemoveItemFromWishListAsync(wishListId, itemId);
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
}