using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using System;
using System.Data.Common;
using Entidades;


namespace GameServer.Hubs
{
    public class GameHub : Hub
    {
       /// <summary>
       /// Task que añadirá al jugador a una sala
       /// </summary>
       /// <param name="player"></param>
       /// <returns></returns>
        public async Task PlayerConnected(clsPlayer player)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, player.GroupName);
            await Clients.OthersInGroup(player.GroupName).SendAsync("PlayerConnected", player);
        }

        public async Task PartidaIniciada(clsPartida nuevaPartida)
        {
            await Clients.Group(nuevaPartida.GroupName).SendAsync("PartidaIniciada", nuevaPartida);
        }

    }
}
