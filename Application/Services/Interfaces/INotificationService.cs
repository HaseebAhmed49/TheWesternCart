using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task AddNotificationAsync(NotificationDto notificationDto);
        Task MarkAsReadAsync(Guid notificationId);
        Task<IEnumerable<NotificationDto>> GetNotificationsByUserIdAsync(string userId);
        Task<IEnumerable<NotificationDto>> GetUnreadNotificationsByUserIdAsync(string userId);
        Task<IEnumerable<NotificationDto>> GetDiscountNotificationsForWishlistAsync(Guid wishlistId);
    }
}