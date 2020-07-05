using Meditation.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalMe
{
    public class MeditationHub : Hub
    {
        readonly IMeditationData meditations;
        public MeditationHub(IMeditationData meditations)
        {
            this.meditations = meditations;
        }
        public async Task SendMeditationMetaData(string liked)
        {
            Console.WriteLine(liked);
            meditations.getById(meditations.getCount() - 1).wasLiked = bool.Parse(liked);
            meditations.updateDictionary(meditations.getById(meditations.getCount() - 1).meditationType, bool.Parse(liked));
            Meditation.Core.Meditation meditation = meditations.CreateNew();
            meditations.add(meditation);
            await Clients.Caller.SendAsync("ReceiveMessage", meditation.name, meditation.content);
        }
    }
}
