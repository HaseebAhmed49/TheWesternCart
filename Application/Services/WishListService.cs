using Application.DTOs;
using Application.Exceptions;
using Application.Services.Interfaces;
using Application.UoW;
using AutoMapper;
using Core.Entities;

namespace FashionClothesAndTrends.Application.Services;

public class WishlistService : IWishListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WishlistService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<WishListDto> CreateWishListAsync(string userId, string name)
    {
        var existingWishlist = await _unitOfWork.WishListRepository.GetWishListByNameAsync(userId, name);
        if (existingWishlist != null)
        {
            throw new ConflictException($"Wishlist with name '{name}' already exists for user '{userId}'.");
        }

        var wishlist = await _unitOfWork.WishListRepository.CreateNewWishListAsync(userId, name);
        return _mapper.Map<WishListDto>(wishlist);
    }

    public async Task<bool> DeleteWishListAsync(Guid wishlistId)
    {
        var wishlist = await _unitOfWork.WishListRepository.GetByIdAsync(wishlistId);
        if (wishlist == null)
        {
            throw new NotFoundException($"Wishlist with ID '{wishlistId}' not found.");
        }

        await _unitOfWork.WishListRepository.RemoveWishListAsync(wishlist);
        return true;
    }

    public async Task<IReadOnlyList<WishListDto>> GetWishListsByUserIdAsync(string userId)
    {
        var wishlists = await _unitOfWork.WishListRepository.GetWishListsByUserIdAsync(userId);
        return _mapper.Map<IReadOnlyList<WishListDto>>(wishlists);
    }

    public async Task<WishListDto?> GetWishListByNameAsync(string userId, string name)
    {
        var wishlist = await _unitOfWork.WishListRepository.GetWishListByNameAsync(userId, name);
        if (wishlist == null)
        {
            throw new NotFoundException($"Wishlist with name '{name}' not found for user '{userId}'.");
        }

        return _mapper.Map<WishListDto>(wishlist);
    }
    public async Task<WishListItemDto> AddItemToWishListAsync(string userId, Guid clothingItemId,
        Guid? wishlistId = null)
    {
        WishList wishlist;

        if (wishlistId.HasValue)
        {
            wishlist = await _unitOfWork.WishListRepository.GetByIdAsync(wishlistId.Value);
            if (wishlist == null)
            {
                throw new NotFoundException($"Wishlist with ID '{wishlistId}' not found for user '{userId}'.");
            }
        }
        else
        {
            wishlist = await _unitOfWork.WishListRepository.GetWishListByNameAsync(userId, "Default");
            if (wishlist == null)
            {
                wishlist = new WishList
                {
                    UserId = userId,
                    Name = "Default",
                    Items = new List<WishListItem>()
                };
                await _unitOfWork.WishListRepository.AddAsync(wishlist);
            }
        }

        var wishlistItem = await _unitOfWork.WishListRepository.AddItemToWishListAsync(wishlist, clothingItemId);
        return _mapper.Map<WishListItemDto>(wishlistItem);
    }

    public async Task<bool> RemoveItemFromWishListAsync(Guid wishlistId, Guid itemId)
    {
        var wishlist = await _unitOfWork.WishListRepository.GetByIdAsync(wishlistId);
        if (wishlist == null)
        {
            throw new NotFoundException($"Wishlist with ID '{wishlistId}' not found.");
        }

        var result = await _unitOfWork.WishListRepository.RemoveItemFromWishListAsync(wishlist, itemId);
        if (!result)
        {
            throw new NotFoundException($"Item with ID '{itemId}' not found in wishlist '{wishlistId}'.");
        }

        return true;
    }
}