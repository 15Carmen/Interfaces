using Microsoft.AspNetCore.SignalR;
using Models;

namespace Ejercicio1.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario usuario)
        {
            await Clients.All.SendAsync("ReceiveMessage", usuario.NombreUsuario, usuario.MensajeUsuario);
        }
    }
}
