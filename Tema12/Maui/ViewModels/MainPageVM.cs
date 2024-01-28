using Ejercicio1.ViewModels.Utils;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;
using System.Runtime.InteropServices;

namespace Maui.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        #region atributos

        private readonly HubConnection hubConnection;
        private clsMensajeUsuario oMensajeUsuario;
        private string nombreUsuario;
        private string mensajeUsuario;
        private ObservableCollection<string> listaChats;
        private DelegateCommand enviarMensajeCommand;
        private string chat;
        

        #endregion

        #region constructores

        public MainPageVM()
        {
            listaChats = new ObservableCollection<string>();

            hubConnection = new HubConnectionBuilder().WithUrl("https://chathubcarmen.azurewebsites.net/chatHub").Build();
            hubConnection.On<clsMensajeUsuario>("ReceiveMessage", (oMensajeUsuario) =>
            {
                listaChats.Add(oMensajeUsuario.NombreUsuario + " says " + oMensajeUsuario.MensajeUsuario);
            });

            Task.Run(async () =>
            {
                await this.hubConnection.StartAsync();
            });
            
            enviarMensajeCommand = new DelegateCommand(EnviarCommand_Execute, EnviarCommand_CanExecute);
            
            
        }

        

        #endregion

        #region propiedades

        public string NombreUsuario{
            get { return nombreUsuario; }
            set {  nombreUsuario = value; enviarMensajeCommand.RaiseCanExecuteChanged(); }
        }

        public string MensajeUsuario
        {
            get { return mensajeUsuario; }
            set { mensajeUsuario = value; enviarMensajeCommand.RaiseCanExecuteChanged(); }
        }

        public DelegateCommand EnviarMensajeCommand {
            get { return enviarMensajeCommand; } 
        }

        public ObservableCollection<string> ListaChats
        {
            get { return listaChats; }
            set { listaChats = value; enviarMensajeCommand.RaiseCanExecuteChanged(); }
        }

        public string Chat
        {
            get { return chat; }
            set { chat = value; enviarMensajeCommand.RaiseCanExecuteChanged();}
        }

        #endregion

        #region commands

        public void EnviarCommand_Execute()
        {
            oMensajeUsuario = new clsMensajeUsuario(NombreUsuario, MensajeUsuario);

            Task.Run(async () =>
            {
                await hubConnection.InvokeCoreAsync("SendMessage", args: new[] {oMensajeUsuario});
            });

            NombreUsuario = String.Empty;
            MensajeUsuario = String.Empty;
            Chat = String.Empty;
            EnviarMensajeCommand.RaiseCanExecuteChanged();
        }

        public bool EnviarCommand_CanExecute()
        {
            bool puedeEnviar = false;

            if(!string.IsNullOrEmpty(NombreUsuario) || !string.IsNullOrEmpty(MensajeUsuario))
            {
                puedeEnviar = true;
            }

            return puedeEnviar;
        }

        #endregion

        #region
       

        #endregion

    }
}
