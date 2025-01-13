using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.Tests
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UsersController _controller;
        public UsersControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UsersController(_userServiceMock.Object);
        }
        [Fact]
        public async Task GetUserByUsername_ReturnsOkResult_WithUser()
        {
            // Arrange
            var username = "testuser";
            var userDto = new UserDto { UserName = username, Email = "test@example.com" };
            _userServiceMock.Setup(service => service.GetUserByUsernameAsync(username))
                .ReturnsAsync(userDto);
            // Act
            var result = await _controller.GetUserByUsername(username);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(userDto.UserName, returnedUser.UserName);
        }
        [Fact]
        public async Task GetUserByEmail_ReturnsOkResult_WithUser()
        {
            // Arrange
            var email = "test@example.com";
            var userDto = new UserDto { UserName = "testuser", Email = email };
            _userServiceMock.Setup(service => service.GetUserByEmailAsync(email))
                .ReturnsAsync(userDto);
            // Act
            var result = await _controller.GetUserByEmail(email);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(userDto.Email, returnedUser.Email);
        }
        [Fact]
        public async Task GetAllUsers_ReturnsOkResult_WithUsers()
        {
            // Arrange
            var usersDto = new List<UserDto>
            {
                new UserDto { UserName = "testuser1", Email = "test1@example.com" },
                new UserDto { UserName = "testuser2", Email = "test2@example.com" }
            };
            _userServiceMock.Setup(service => service.GetAllUsersAsync())
                .ReturnsAsync(usersDto);
            // Act
            var result = await _controller.GetAllUsers();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsType<List<UserDto>>(okResult.Value);
            Assert.Equal(usersDto.Count, returnedUsers.Count);
        }
        [Fact]
        public async Task SearchUsersByName_ReturnsOkResult_WithUsers()
        {
            // Arrange
            var name = "test";
            var usersDto = new List<UserDto>
            {
                new UserDto { UserName = "testuser1", Email = "test1@example.com" },
                new UserDto { UserName = "testuser2", Email = "test2@example.com" }
            };
            _userServiceMock.Setup(service => service.SearchUsersByNameAsync(name))
                .ReturnsAsync(usersDto);
            // Act
            var result = await _controller.SearchUsersByName(name);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsType<List<UserDto>>(okResult.Value);
            Assert.Equal(usersDto.Count, returnedUsers.Count);
        }
    }
}