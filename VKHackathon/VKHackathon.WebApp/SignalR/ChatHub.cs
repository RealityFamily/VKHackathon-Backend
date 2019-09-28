using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VKHackathon.WebApp.SignalR
{
    public class ChatHub : Hub
    {
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.Caller.SendAsync("ConnectionId", Context.ConnectionId);
        //}
    }
}
