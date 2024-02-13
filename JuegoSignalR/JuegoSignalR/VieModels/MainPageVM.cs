using JuegoSignalR.ViewModels.Utils;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.SignalR.Client;

namespace JuegoSignalR.VieModels
{
    public class MainPageVM : clsVMBase
    {
        private readonly HubConnection hubConnection;


        public MainPageVM()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/gamehub")
                .Build();

            hubConnection.StartAsync();

           // hubConnection.On<int>("MoveMade, ");
        }



    }
}
