using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Controllers;
using API.Errors;
using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.Tests
{
    public class WishListControllerTests
    {
        private readonly Mock<IWishListService> _wishListServiceMock;
        private readonly WishListController _controller;
        public WishListControllerTests()
        {
            _wishListServiceMock = new Mock<IWishListService>();
            _controller = new WishListController(_wishListServiceMock.Object);
            // Set up a mock user
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "test_user_id")
            }, "mock"));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }
        [Fact]
        public async Task GetWishListsByUserId_ReturnsOkResult_WithWishLists()
        {
            // Arrange
            var userId = "test_user_id";
            var wishLists = new List<WishListDto>
            {
                new WishListDto { Id = Guid.NewGuid(), Name = "WishList 1" },
                new WishListDto { Id = Guid.NewGuid(), Name = "WishList 2" }
            };
            _wishListServiceMock.Setup(service => service.GetWishListsByUserIdAsync(userId))
                .ReturnsAsync(wishLists);
            // Act
            var result = await _controller.GetWishListsByUserId();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedWishLists = Assert.IsType<List<WishListDto>>(okResult.Value);
            Assert.Equal(wishLists.Count, returnedWishLists.Count);
        }
        [Fact]
        public async Task GetWishListsByUserId_ReturnsNotFound_WhenNotFoundExceptionThrown()
        {
            // Arrange
            var userId = "test_user_id";
            _wishListServiceMock.Setup(service => service.GetWishListsByUserIdAsync(userId))
                .ThrowsAsync(new NotFoundException("No wishLists found for this user."));
            // Act
            var result = await _controller.GetWishListsByUserId();
            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse>(notFoundResult.Value);
            Assert.Equal(404, apiResponse.StatusCode);
            Assert.Equal("No wishLists found for this user.", apiResponse.Message);
        }
        [Fact]
        public async Task GetWishListsByUserId_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "test_user_id";
            _wishListServiceMock.Setup(service => service.GetWishListsByUserIdAsync(userId))
                .ThrowsAsync(new Exception("Test exception"));
            // Act
            var result = await _controller.GetWishListsByUserId();
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var apiResponse = Assert.IsType<ApiResponse>(statusCodeResult.Value);
            Assert.Equal(500, apiResponse.StatusCode);
            Assert.Equal("An error occurred while processing your request", apiResponse.Message);
        }
        [Fact]
        public async Task GetWishListByName_ReturnsOkResult_WithWishList()
        {
            // Arrange
            var userId = "test_user_id";
            var wishList = new WishListDto { Id = Guid.NewGuid(), Name = "WishList 1" };
            _wishListServiceMock.Setup(service => service.GetWishListByNameAsync(userId, "WishList 1"))
                .ReturnsAsync(wishList);
            // Act
            var result = await _controller.GetWishListByName("WishList 1");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedWishList = Assert.IsType<WishListDto>(okResult.Value);
            Assert.Equal(wishList.Name, returnedWishList.Name);
        }
        [Fact]
        public async Task GetWishListByName_ReturnsNotFound_WhenNotFoundExceptionThrown()
        {
            // Arrange
            var userId = "test_user_id";
            _wishListServiceMock.Setup(service => service.GetWishListByNameAsync(userId, "WishList 1"))
                .ThrowsAsync(new NotFoundException("WishList with name 'WishList 1' not found for user 'test_user_id'."));
            // Act
            var result = await _controller.GetWishListByName("WishList 1");
            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse>(notFoundResult.Value);
            Assert.Equal(404, apiResponse.StatusCode);
            Assert.Equal("WishList with name 'WishList 1' not found for user 'test_user_id'.", apiResponse.Message);
        }
        [Fact]
        public async Task GetWishListByName_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "test_user_id";
            _wishListServiceMock.Setup(service => service.GetWishListByNameAsync(userId, "WishList 1"))
                .ThrowsAsync(new Exception("Test exception"));
            // Act
            var result = await _controller.GetWishListByName("WishList 1");
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var apiResponse = Assert.IsType<ApiResponse>(statusCodeResult.Value);
            Assert.Equal(500, apiResponse.StatusCode);
            Assert.Equal("An error occurred while processing your request", apiResponse.Message);
        }
        [Fact]
        public async Task CreateWishList_ReturnsCreatedAtActionResult_WithWishList()
        {
            // Arrange
            var userId = "test_user_id";
            var wishList = new WishListDto { Id = Guid.NewGuid(), Name = "WishList 1" };
            _wishListServiceMock.Setup(service => service.CreateWishListAsync(userId, "WishList 1"))
                .ReturnsAsync(wishList);
            // Act
            var result = await _controller.CreateWishList(userId, "WishList 1");
            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedWishList = Assert.IsType<WishListDto>(createdAtActionResult.Value);
            Assert.Equal(wishList.Name, returnedWishList.Name);
        }
        [Fact]
        public async Task CreateWishList_ReturnsConflict_WhenConflictExceptionThrown()
        {
            // Arrange
            var userId = "test_user_id";
            _wishListServiceMock.Setup(service => service.CreateWishListAsync(userId, "WishList 1"))
                .ThrowsAsync(
                    new ConflictException("WishList with name 'WishList 1' already exists for user 'test_user_id'."));
            // Act
            var result = await _controller.CreateWishList(userId, "WishList 1");
            // Assert
            var conflictResult = Assert.IsType<ConflictObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse>(conflictResult.Value);
            Assert.Equal(409, apiResponse.StatusCode);
            Assert.Equal("WishList with name 'WishList 1' already exists for user 'test_user_id'.", apiResponse.Message);
        }
        [Fact]
        public async Task CreateWishList_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var userId = "test_user_id";
            _wishListServiceMock.Setup(service => service.CreateWishListAsync(userId, "WishList 1"))
                .ThrowsAsync(new Exception("Test exception"));
            // Act
            var result = await _controller.CreateWishList(userId, "WishList 1");
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var apiResponse = Assert.IsType<ApiResponse>(statusCodeResult.Value);
            Assert.Equal(500, apiResponse.StatusCode);
            Assert.Equal("An error occurred while processing your request", apiResponse.Message);
        }
        [Fact]
        public async Task DeleteWishList_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            var wishListId = Guid.NewGuid();
            _wishListServiceMock.Setup(service => service.DeleteWishListAsync(wishListId))
                .ReturnsAsync(true);
            // Act
            var result = await _controller.DeleteWishList(wishListId);
            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task DeleteWishList_ReturnsNotFound_WhenNotFoundExceptionThrown()
        {
            // Arrange
            var wishListId = Guid.NewGuid();
            _wishListServiceMock.Setup(service => service.DeleteWishListAsync(wishListId))
                .ThrowsAsync(new NotFoundException("WishList with ID 'wishListId' not found."));
            // Act
            var result = await _controller.DeleteWishList(wishListId);
            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse>(notFoundResult.Value);
            Assert.Equal(404, apiResponse.StatusCode);
            Assert.Equal("WishList with ID 'wishListId' not found.", apiResponse.Message);
        }
        [Fact]
        public async Task DeleteWishList_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var wishListId = Guid.NewGuid();
            _wishListServiceMock.Setup(service => service.DeleteWishListAsync(wishListId))
                .ThrowsAsync(new Exception("Test exception"));
            // Act
            var result = await _controller.DeleteWishList(wishListId);
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var apiResponse = Assert.IsType<ApiResponse>(statusCodeResult.Value);
            Assert.Equal(500, apiResponse.StatusCode);
            Assert.Equal("An error occurred while processing your request", apiResponse.Message);
        }
        [Fact]
        public async Task AddItemToWishList_ReturnsOkResult_WithWishListItem()
        {
            // Arrange
            var wishListId = Guid.NewGuid();
            var clothingItemId = Guid.NewGuid();
            var wishListItem = new WishListItemDto
                { Id = Guid.NewGuid(), ClothingItemId = clothingItemId, ClothingItemName = "Item 1" };
            _wishListServiceMock.Setup(service => service.AddItemToWishListAsync(wishListId, clothingItemId))
                .ReturnsAsync(wishListItem);
            // Act
            var result = await _controller.AddItemToWishList(wishListId, clothingItemId);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedWishListItem = Assert.IsType<WishListItemDto>(okResult.Value);
            Assert.Equal(wishListItem.ClothingItemName, returnedWishListItem.ClothingItemName);
        }
        [Fact]
        public async Task AddItemToWishList_ReturnsNotFound_WhenNotFoundExceptionThrown()
        {
            // Arrange
            var wishListId = Guid.NewGuid();
            var clothingItemId = Guid.NewGuid();
            _wishListServiceMock.Setup(service => service.AddItemToWishListAsync(wishListId, clothingItemId))
                .ThrowsAsync(new NotFoundException("WishList with ID 'wishListId' not found."));
            // Act
            var result = await _controller.AddItemToWishList(wishListId, clothingItemId);
            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse>(notFoundResult.Value);
            Assert.Equal(404, apiResponse.StatusCode);
            Assert.Equal("WishList with ID 'wishListId' not found.", apiResponse.Message);
        }
        [Fact]
        public async Task AddItemToWishList_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var wishListId = Guid.NewGuid();
            var clothingItemId = Guid.NewGuid();
            _wishListServiceMock.Setup(service => service.AddItemToWishListAsync(wishListId, clothingItemId))
                .ThrowsAsync(new Exception("Test exception"));
            // Act
            var result = await _controller.AddItemToWishList(wishListId, clothingItemId);
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var apiResponse = Assert.IsType<ApiResponse>(statusCodeResult.Value);
            Assert.Equal(500, apiResponse.StatusCode);
            Assert.Equal("An error occurred while processing your request", apiResponse.Message);
        }
        [Fact]
        public async Task RemoveItemFromWishList_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            var wishListId = Guid.NewGuid();
            var itemId = Guid.NewGuid();
            _wishListServiceMock.Setup(service => service.RemoveItemFromWishListAsync(wishListId, itemId))
                .ReturnsAsync(true);
            // Act
            var result = await _controller.RemoveItemFromWishList(wishListId, itemId);
            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}