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
    public class OrdersHistoryController : BaseApiController
    {
        private readonly IOrderHistoryService _orderHistoryService;
        public OrdersHistoryController(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IReadOnlyList<OrderHistoryDto>>> GetOrderHistoriesForUser(string userId)
        {
            try
            {
                var orderHistories = await _orderHistoryService.GetOrderHistoriesForUserAsync(userId);
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
    }
}