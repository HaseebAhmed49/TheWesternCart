using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions;
using Application.Helpers;
using Application.Services.Interfaces;
using Application.UoW;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Core.Entities;
using Core.Specifications;

namespace Application.Services
{
    public class ClothingItemService : IClothingItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public ClothingItemService(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<ClothingItemDto> GetClothingItem(Guid clothingItemId)
        {
            var spec = new ClothingItemWithTypesAndBrandsSpecification(clothingItemId);
            var clothingItem = await _unitOfWork.GenericRepository<ClothingItem>().GetEntityWithSpec(spec);
            if (clothingItem == null) throw new  NotFoundException("ClothingItem not found.");
            return _mapper.Map<ClothingItem, ClothingItemDto>(clothingItem);
        }
        public async Task<Pagination<ClothingItemDto>> GetClothingItems(ClothingSpecParams clothingSpecParamsParams)
        {
            var spec = new ClothingItemWithTypesAndBrandsSpecification(clothingSpecParamsParams);
            var countSpec = new ClothingItemWithFiltersForCountSpecification(clothingSpecParamsParams);
            var totalItems = await _unitOfWork.GenericRepository<ClothingItem>().CountAsync(countSpec);
            var clothingItems = await _unitOfWork.GenericRepository<ClothingItem>().ListAsync(spec);
            var data = _mapper
                .Map<IReadOnlyList<ClothingItem>, IReadOnlyList<ClothingItemDto>>(clothingItems);
            
            return new Pagination<ClothingItemDto>(clothingSpecParamsParams.PageIndex, clothingSpecParamsParams.PageSize, totalItems, data);
        }
        public async Task<IReadOnlyList<ClothingBrand>> GetClothingBrands()
        {
            return await _unitOfWork.GenericRepository<ClothingBrand>().ListAllAsync();
        }
        
        public async Task<ClothingItemPhotoDto> AddPhotoByClothingItem(ImageUploadResult result, Guid clothingItemId)
        {
            var clothingItem = await _unitOfWork.ClothingItemRepository.GetClothingByIdAsync(clothingItemId);
            if (clothingItem == null) throw new NotFoundException("Clothing item not found!");
            var photo = new ClothingItemPhoto
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            clothingItem.ClothingItemPhotos.Add(photo);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ClothingItemPhotoDto>(photo);
        }
        public async Task SetMainClothingItemPhotoByClothingItem(Guid clothingItemPhotoId, Guid clothingItemId)
        {
            var clothingItem = await _unitOfWork.ClothingItemRepository.GetClothingByIdAsync(clothingItemId);
            if (clothingItem == null) throw new NotFoundException("Clothing item not found!");
            var photo = clothingItem.ClothingItemPhotos.FirstOrDefault(p => p.Id == clothingItemPhotoId);
            if (photo == null) throw new NotFoundException("Photo not found!");
            var currentMain = clothingItem.ClothingItemPhotos.FirstOrDefault(p => p.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photo.IsMain = true;
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteClothingItemPhotoByClothingItem(Guid clothingItemPhotoId, Guid clothingItemId)
        {
            var clothingItem = await _unitOfWork.ClothingItemRepository.GetClothingByIdAsync(clothingItemId);
            var photo = await _unitOfWork.PhotoRepository.GetClothingItemPhotoByIdAsync(clothingItemPhotoId);
            if (photo == null) throw new NotFoundException("Not Found!");
            if (photo.IsMain) throw new ForbiddenException("You cannot delete your main photo");
            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) throw new ConflictException("Error!");
            }
            clothingItem.ClothingItemPhotos.Remove(photo);
            await _unitOfWork.SaveAsync();
        }
        
    }
}