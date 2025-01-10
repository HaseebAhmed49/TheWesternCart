using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using Application.UoW;
using AutoMapper;
using Core.Entities;

namespace Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RatingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task AddRatingAsync(Guid clothingItemId, RatingDto ratingDto)
        {
            if (ratingDto == null)
            {
                throw new ArgumentNullException(nameof(ratingDto));
            }
            var rating = _mapper.Map<Rating>(ratingDto);
            await _unitOfWork.RatingRepository.AddRatingToClothingItemAsync(clothingItemId, rating);
        }
        public async Task<double?> GetAverageRatingAsync(Guid clothingItemId)
        {
            return await _unitOfWork.RatingRepository.GetAverageRatingByClothingItemIdAsync(clothingItemId);
        }
        
        public async Task UpdateRatingAsync(RatingDto ratingDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUserName(ratingDto.UserName);
            await _unitOfWork.RatingRepository.UpdateRatingAsync(user.Id, ratingDto.ClothingItemId, ratingDto.Score);
        }
    }
}