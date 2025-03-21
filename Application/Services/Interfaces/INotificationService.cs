using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Core.Entities;

namespace Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task AddNotificationAsync(Notification notification);
        Task<IEnumerable<NotificationDto>> GetNotificationsByUserIdAsync(string userId);
        Task<IEnumerable<NotificationDto>> GetUnreadNotificationsByUserIdAsync(string userId);

    }
}