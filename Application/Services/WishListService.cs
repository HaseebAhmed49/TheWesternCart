using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Application.UoW;
using AutoMapper;
using Core.Entities;

namespace Application.Services
{
    public class WishListService : IWishListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WishListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<WishListDto>> GetWishListsByUserIdAsync(string userId)
        {
            var wishLists = await _unitOfWork.WishListRepository.GetWishListsByUserIdAsync(userId);
            return _mapper.Map<IReadOnlyList<WishListDto>>(wishLists);
        }

        public async Task<WishListDto?> GetWishListByNameAsync(string userId, string name)
        {
            var wishList = await _unitOfWork.WishListRepository.GetWishListByNameAsync(
                userId,
                name
            );
            if (wishList == null)
            {
                throw new NotFoundException(
                    $"WishList with name '{name}' not found for user '{userId}'."
                );
            }
            return _mapper.Map<WishListDto>(wishList);
        }

        public async Task<WishListDto> CreateWishListAsync(string userId, string name)
        {
            var existingWishList = await _unitOfWork.WishListRepository.GetWishListByNameAsync(
                userId,
                name
            );
            if (existingWishList != null)
            {
                throw new ConflictException(
                    $"WishList with name '{name}' already exists for user '{userId}'."
                );
            }
            var wishList = new WishList
            {
                UserId = userId,
                Name = name,
                Items = new List<WishListItem>(),
            };
            await _unitOfWork.WishListRepository.AddAsync(wishList);
            return _mapper.Map<WishListDto>(wishList);
        }

        public async Task<bool> DeleteWishListAsync(Guid wishListId)
        {
            var wishList = await _unitOfWork.WishListRepository.GetByIdAsync(wishListId);
            if (wishList == null)
            {
                throw new NotFoundException($"WishList with ID '{wishListId}' not found.");
            }
            await _unitOfWork.WishListRepository.RemoveAsync(wishList);
            return true;
        }

        public async Task<WishListItemDto> AddItemToWishListAsync(
            Guid wishListId,
            Guid clothingItemId
        )
        {
            var wishList = await _unitOfWork.WishListRepository.GetByIdAsync(wishListId);
            if (wishList == null)
            {
                throw new NotFoundException($"WishList with ID '{wishListId}' not found.");
            }
            var wishListItem = new WishListItem
            {
                WishListId = wishListId,
                ClothingItemId = clothingItemId,
            };
            wishList.Items.Add(wishListItem);
            await _unitOfWork.WishListRepository.UpdateAsync(wishList);
            return _mapper.Map<WishListItemDto>(wishListItem);
        }

        public async Task<bool> RemoveItemFromWishListAsync(Guid wishListId, Guid itemId)
        {
            var wishList = await _unitOfWork.WishListRepository.GetByIdAsync(wishListId);
            if (wishList == null)
            {
                throw new NotFoundException($"WishList with ID '{wishListId}' not found.");
            }
            var item = wishList.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                throw new NotFoundException(
                    $"Item with ID '{itemId}' not found in wishList '{wishListId}'."
                );
            }
            wishList.Items.Remove(item);
            await _unitOfWork.WishListRepository.UpdateAsync(wishList);
            return true;
        }
    }
}
