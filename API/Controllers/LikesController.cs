using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    public class LikesController : BaseApiController
    {
        private readonly ILikeDislikeService _likeDislikeService;

        public LikesController(ILikeDislikeService likeDislikeService)
        {
            _likeDislikeService = likeDislikeService;
        }

        [HttpPost]
        public async Task<ActionResult> AddLikeDislike(LikeDislikeDto likeDislikeDto)
        {
            try
            {
                await _likeDislikeService.AddLikeDislikeAsync(likeDislikeDto);
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

        [HttpDelete("{likeDislikeId}")]
        public async Task<ActionResult> RemoveLikeDislike(Guid likeDislikeId)
        {
            try
            {
                await _likeDislikeService.RemoveLikeDislikeAsync(likeDislikeId);
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

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<IEnumerable<LikeDislikeDto>>> GetLikesDislikesByUserId(string userId)
        {
            try
            {
                var likesDislikes = await _likeDislikeService.GetLikesDislikesByUserIdAsync(userId);
                return Ok(likesDislikes);
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

        [HttpGet("comments/{commentId}")]
        public async Task<ActionResult<IEnumerable<LikeDislikeDto>>> GetLikesDislikesByCommentId(Guid commentId)
        {
            try
            {
                var likesDislikes = await _likeDislikeService.GetLikesDislikesByCommentIdAsync(commentId);
                return Ok(likesDislikes);
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

        [HttpGet("comments/{commentId}/likes")]
        public async Task<ActionResult<int>> GetLikesCount(Guid commentId)
        {
            try
            {
                var count = await _likeDislikeService.CountLikesAsync(commentId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        
        [HttpGet("comments/{commentId}/dislikes")]
        public async Task<ActionResult<int>> GetDislikesCount(Guid commentId)
        {
            try
            {
                var count = await _likeDislikeService.CountDislikesAsync(commentId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
    }
}