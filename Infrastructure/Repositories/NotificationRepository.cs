using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IReadOnlyList<Notification>> GetNotificationsByUserIdAsync(string userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<Notification>> GetUnreadNotificationsByUserIdAsync(string userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<Notification>> GetDiscountNotificationsForWishlistAsync(Guid wishlistId)
        {
            return await _context.Notifications
                .Where(n => n.User.Wishlists.Any(w => w.Id == wishlistId) && n.Text.Contains("discount"))
                .ToListAsync();
        }
        public async Task<bool> AddNotificationAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> MarkAsReadAsync(Guid notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification == null)
            {
                return false;
            }
            notification.IsRead = true;
            _context.Notifications.Update(notification);
            return await _context.SaveChangesAsync() > 0;
        }
        
    }
}