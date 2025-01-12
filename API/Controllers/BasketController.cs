using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    public class BasketController : BaseApiController
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _mapper = mapper;
            _basketService = basketService;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            try
            {
                var basket = await _basketService.GetBasketAsync(id);
                return Ok(basket ?? new CustomerBasket(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            try
            {
                var customerBasket = _mapper.Map<CustomerBasket>(basket);
                var updatedBasket = await _basketService.UpdateBasketAsync(customerBasket);
                return Ok(updatedBasket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBasketAsync(string id)
        {
            try
            {
                await _basketService.DeleteBasketAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing your request"));
            }
        }
    }
}