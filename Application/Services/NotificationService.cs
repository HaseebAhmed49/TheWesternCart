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
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public Task AddNotificationAsync(Notification notification)
        {
            return _unitOfWork.NotificationRepository.AddNotificationAsync(notification);
        }
    
        public async Task<IEnumerable<NotificationDto>> GetNotificationsByUserIdAsync(string userId)
        {
            var notifications = await _unitOfWork.NotificationRepository.GetNotificationsByUserIdAsync(userId);
            if (notifications == null || !notifications.Any())
            {
                throw new NotFoundException("No notifications found for this user.");
            }
            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }
        public async Task<IEnumerable<NotificationDto>> GetUnreadNotificationsByUserIdAsync(string userId)
        {
            var notifications = await _unitOfWork.NotificationRepository.GetUnreadNotificationsByUserIdAsync(userId);
            if (notifications == null || !notifications.Any())
            {
                throw new NotFoundException("No unread notifications found for this user.");
            }
            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }        
    }
}