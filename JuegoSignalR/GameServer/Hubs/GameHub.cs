using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using System;

namespace GameServer.Hubs
{
    public class GameHub : Hub
    {
        public async Task JoinGame(string gameId)
        {
            
        }

        public async Task MakeMove(string gameId, int column)
        {
           
        }
    }
}
