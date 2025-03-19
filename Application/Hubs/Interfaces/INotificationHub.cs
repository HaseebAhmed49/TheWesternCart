using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Hubs.Interfaces
{
    public interface INotificationHub
    {
        public Task SendMessage(Notification notification);
    }
}