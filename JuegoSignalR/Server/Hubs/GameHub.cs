using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class GameHub : Hub
    {

        public async Task JoinGame(string gameId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
        }

        public async Task MakeMove(string gameId, int column)
        {
            // Lógica para realizar un movimiento en el juego
            // Por ejemplo, validar el movimiento, actualizar el estado del juego, etc.

            // Notificar a los jugadores sobre el movimiento realizado
            await Clients.Group(gameId).SendAsync("MoveMade", column);
        }

    }
}
