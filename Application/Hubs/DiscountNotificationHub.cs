using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Application.Hubs
{
    public class DiscountNotificationHub : Hub<INotificationHub>
{
    public Task SubscribeToUser(string userId)
    {
        return this.Groups.AddToGroupAsync(Context.ConnectionId, userId);
    }
        
    }
}