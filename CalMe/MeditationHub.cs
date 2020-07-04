using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalMe
{
    public class MeditationHub : Hub
    {
        public async Task SendMeditationMetaData(string meditationName, string messageContent, string liked = null)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", meditationName, messageContent);
        }
    }
}
