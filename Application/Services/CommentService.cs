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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddCommentAsync(CommentDto commentDto)
        {
            if (commentDto == null)
            {
                throw new ArgumentNullException(nameof(commentDto));
            }
            var comment = _mapper.Map<Comment>(commentDto);
            await _unitOfWork.CommentRepository.AddAsync(comment);
            await _unitOfWork.SaveAsync();
        }
        public async Task RemoveCommentAsync(Guid commentId)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(commentId);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found.");
            }
            _unitOfWork.CommentRepository.Remove(comment);
            await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<CommentDto>> GetCommentsForClothingItemAsync(Guid clothingItemId)
        {
            var comments = await _unitOfWork.CommentRepository.GetCommentsForClothingItemIdAsync(clothingItemId);
            if (comments == null || !comments.Any())
            {
                throw new NotFoundException("No comments found for this clothing item.");
            }
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }
        public async Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(string userId)
        {
            var comments = await _unitOfWork.CommentRepository.GetCommentsByUserIdAsync(userId);
            if (comments == null || !comments.Any())
            {
                throw new NotFoundException("No comments found for this user.");
            }
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }
        
    }
}