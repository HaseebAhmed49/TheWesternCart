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
    public class CommentsController : BaseApiController
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        [HttpPost]
        public async Task<ActionResult> AddComment(CommentDto commentDto)
        {
            try
            {
                await _commentService.AddCommentAsync(commentDto);
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

        [HttpDelete("{commentId}")]
        public async Task<ActionResult> RemoveComment(Guid commentId)
        {
            try
            {
                var userId = User.GetUserId();
                if (userId == null) return Unauthorized();
                
                await _commentService.RemoveCommentAsync(commentId, userId);
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

        [HttpGet("clothing/{clothingItemId}")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetCommentsForClothingItem(Guid clothingItemId)
        {
            try
            {
                var comments = await _commentService.GetCommentsForClothingItemAsync(clothingItemId);
                return Ok(comments);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse(404, "No comments found for this item."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetCommentsByUserId(string userId)
        {
            try
            {
                var comments = await _commentService.GetCommentsByUserIdAsync(userId);
                return Ok(comments);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse(404, "No comments found for this user."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
    }
}