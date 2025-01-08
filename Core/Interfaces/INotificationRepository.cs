using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface INotificationRepository
    {
        Task<IReadOnlyList<Notification>> GetNotificationsByUserIdAsync(string userId);
        Task<IReadOnlyList<Notification>> GetUnreadNotificationsByUserIdAsync(string userId);
        Task<IReadOnlyList<Notification>> GetDiscountNotificationsForWishlistAsync(Guid wishlistId);
        Task<bool> AddNotificationAsync(Notification notification);
        Task<bool> MarkAsReadAsync(Guid notificationId); 
    }
}