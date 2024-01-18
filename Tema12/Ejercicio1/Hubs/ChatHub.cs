using Microsoft.AspNetCore.SignalR;
using Models;

namespace Ejercicio1.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario oMensajeUsuario)
        {
            await Clients.All.SendAsync("ReceiveMessage", oMensajeUsuario);
        }
    }
}
