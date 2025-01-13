
using System.Security.Claims;
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
    public class FavouritesControllerTests
    {
        private readonly Mock<IFavouriteItemService> _favoriteItemServiceMock;
        private readonly FavouritesController _controller;
        public FavouritesControllerTests()
        {
            _favoriteItemServiceMock = new Mock<IFavouriteItemService>();
            _controller = new FavouritesController(_favoriteItemServiceMock.Object);
            // Mocking the User in the controller context
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
        public async Task AddFavorite_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var clothingItemId = Guid.NewGuid();
            // Act
            var result = await _controller.AddFavorite(clothingItemId);
            // Assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async Task AddFavorite_ReturnsConflict_WhenConflictExceptionThrown()
        {
            // Arrange
            var clothingItemId = Guid.NewGuid();
            _favoriteItemServiceMock.Setup(service => service.AddFavoriteAsync(clothingItemId, "test_user_id"))
                .ThrowsAsync(new ConflictException("This item is already in the favorites."));
            // Act
            var result = await _controller.AddFavorite(clothingItemId);
            // Assert
            var conflictResult = Assert.IsType<ConflictObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse>(conflictResult.Value);
            Assert.Equal(409, apiResponse.StatusCode);
            Assert.Equal("This item is already in the favorites.", apiResponse.Message);
        }
        [Fact]
        public async Task RemoveFavorite_ReturnsNoContentResult_WhenSuccessful()
        {
            // Arrange
            var clothingItemId = Guid.NewGuid();
            // Act
            var result = await _controller.RemoveFavorite(clothingItemId);
            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task RemoveFavorite_ReturnsNotFound_WhenNotFoundExceptionThrown()
        {
            // Arrange
            var clothingItemId = Guid.NewGuid();
            _favoriteItemServiceMock.Setup(service => service.RemoveFavoriteAsync(clothingItemId, "test_user_id"))
                .ThrowsAsync(new NotFoundException("Favorite item not found."));
            // Act
            var result = await _controller.RemoveFavorite(clothingItemId);
            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse>(notFoundResult.Value);
            Assert.Equal(404, apiResponse.StatusCode);
            Assert.Equal("Favorite item not found.", apiResponse.Message);
        }
        [Fact]
        public async Task GetFavoritesByUserId_ReturnsOkResult_WithFavoriteItems()
        {
            // Arrange
            var favoriteItems = new List<FavouriteItemDto>
            {
                new FavouriteItemDto { UserDtoId = "test_user_id", ClothingItemDtoId = Guid.NewGuid() },
                new FavouriteItemDto { UserDtoId = "test_user_id", ClothingItemDtoId = Guid.NewGuid() }
            };
            _favoriteItemServiceMock.Setup(service => service.GetFavoritesByUserIdAsync("test_user_id"))
                .ReturnsAsync(favoriteItems);
            // Act
            var result = await _controller.GetFavoritesByUserId();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedFavoriteItems = Assert.IsType<List<FavouriteItemDto>>(okResult.Value);
            Assert.Equal(favoriteItems.Count, returnedFavoriteItems.Count);
        }
        [Fact]
        public async Task GetFavoritesByUserId_ReturnsNotFound_WhenNotFoundExceptionThrown()
        {
            // Arrange
            _favoriteItemServiceMock.Setup(service => service.GetFavoritesByUserIdAsync("test_user_id"))
                .ThrowsAsync(new NotFoundException("No favorite items found for this user."));
            // Act
            var result = await _controller.GetFavoritesByUserId();
            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse>(notFoundResult.Value);
            Assert.Equal(404, apiResponse.StatusCode);
            Assert.Equal("No favorite items found for this user.", apiResponse.Message);
        }
        [Fact]
        public async Task IsFavorite_ReturnsOkResult_WithIsFavorite()
        {
            // Arrange
            var clothingItemId = Guid.NewGuid();
            _favoriteItemServiceMock.Setup(service => service.IsFavoriteAsync(clothingItemId, "test_user_id"))
                .ReturnsAsync(true);
            // Act
            var result = await _controller.IsFavorite(clothingItemId);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var isFavorite = Assert.IsType<bool>(okResult.Value);
            Assert.True(isFavorite);
        }
    }
}