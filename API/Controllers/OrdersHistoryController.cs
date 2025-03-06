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
    public class OrdersHistoryController : BaseApiController
    {
        private readonly IOrderHistoryService _orderHistoryService;
        public OrdersHistoryController(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        [HttpGet("user")]
        public async Task<ActionResult<IReadOnlyList<OrderHistoryToReturnDto>>> GetOrderHistoriesByUserId()
        {
            try
            {
                var userId = User.GetUserId();
                var orderHistories = await _orderHistoryService.GetOrderHistoriesByUserIdAsync(userId);
                if (orderHistories == null || !orderHistories.Any())
                {
                    return NotFound(new ApiResponse(404, $"Order histories not found for user with ID '{userId}'."));
                }
                return Ok(orderHistories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        
        [HttpGet("order/{id}")]
        public async Task<ActionResult<OrderHistoryDto>> GetOrderHistoryById(Guid id)
        {
            try
            {
                var orderHistory = await _orderHistoryService.GetOrderHistoryByIdAsync(id);
                return Ok(orderHistory);
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderHistoryToReturnDto>>> GetAllOrderHistories()
        {
            try
            {
                var orderHistories = await _orderHistoryService.GatAllOrderHistoriesAsync();
                if (orderHistories == null || !orderHistories.Any())
                {
                    return NotFound(new ApiResponse(404, "Order histories not found."));
                }
                return Ok(orderHistories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
    }
}