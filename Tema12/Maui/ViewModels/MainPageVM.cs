using Ejercicio1.ViewModels.Utils;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;

namespace Maui.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        #region atributos

        private readonly HubConnection hubConnection;
        private clsMensajeUsuario oMensajeUsuario;
        private string nombreUsuario;
        private string mensajeUsuario;
        private DelegateCommand enviarMensajeCommand;
        private ObservableCollection<clsMensajeUsuario> listaChats;
        

        #endregion

        #region constructores

        public MainPageVM()
        {
            hubConnection = new HubConnectionBuilder().WithUrl("https://chathubcarmen.azurewebsites.net/chatHub").Build();
            hubConnection.On<clsMensajeUsuario>("ReceiveMessage", ReceiveMessage);
            nombreUsuario = string.Empty;
            mensajeUsuario = string.Empty;
            listaChats = new ObservableCollection<clsMensajeUsuario>();
            enviarMensajeCommand = new DelegateCommand(EnviarCommand_Execute, EnviarCommand_CanExecute);
        }

        private void ReceiveMessage(clsMensajeUsuario mensaje)
        {
            mensaje = new clsMensajeUsuario(NombreUsuario, MensajeUsuario);

            Task.Run(async () =>
            {
                await hubConnection.StartAsync();
            });

        }

        #endregion

        #region propiedades

        public string NombreUsuario{
            get { return nombreUsuario; }
            set {  nombreUsuario = value; }
        }

        public string MensajeUsuario
        {
            get { return mensajeUsuario; }
            set { mensajeUsuario = value; }
        }

        public DelegateCommand EnviarMensajeCommand {
            get { return enviarMensajeCommand; } 
        }

        public ObservableCollection<clsMensajeUsuario> ListaChats
        {
            get { return listaChats; }
        }

        #endregion

        #region commands

        public void EnviarCommand_Execute()
        {
            // Validar que se haya ingresado un nombre de usuario y un mensaje antes de enviar
            if (!string.IsNullOrWhiteSpace(NombreUsuario) && !string.IsNullOrWhiteSpace(MensajeUsuario))
            {
                // Crear un nuevo objeto clsMensajeUsuario y agregarlo a la lista de chats
                oMensajeUsuario = new clsMensajeUsuario(NombreUsuario, MensajeUsuario);
                ListaChats.Add(oMensajeUsuario);

                // Limpiar los campos después de enviar el mensaje
                MensajeUsuario = string.Empty;
                EnviarMensajeCommand.RaiseCanExecuteChanged();
            }
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

    }
}
