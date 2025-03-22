using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<IReadOnlyList<Notification>> GetNotificationsByUserIdAsync(string userId);
        Task<IReadOnlyList<Notification>> GetUnreadNotificationsByUserIdAsync(string userId);
        Task<bool> AddNotificationAsync(Notification notification);
    }
}