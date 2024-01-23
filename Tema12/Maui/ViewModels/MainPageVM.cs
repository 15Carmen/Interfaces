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

        private clsMensajeUsuario oMensajeUsuario;
        private string nombreUsuario;
        private string mensajeUsuario;
        private DelegateCommand enviarMensajeCommand;
        private ObservableCollection<clsMensajeUsuario> listaChats;
        private readonly HubConnection hubConnection;

        #endregion

        #region constructores

        public MainPageVM()
        {
            listaChats = new ObservableCollection<clsMensajeUsuario>();
            enviarMensajeCommand = new DelegateCommand(enviarExecute, enviarCanExecute);
            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.21:5252").Build();
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

        public void enviarExecute()
        {
            // Validar que se haya ingresado un nombre de usuario y un mensaje antes de enviar
            if (!string.IsNullOrWhiteSpace(NombreUsuario) && !string.IsNullOrWhiteSpace(MensajeUsuario))
            {
                // Crear un nuevo objeto clsMensajeUsuario y agregarlo a la lista de chats
                oMensajeUsuario = new clsMensajeUsuario(NombreUsuario, MensajeUsuario);
                ListaChats.Add(oMensajeUsuario);

                // Limpiar los campos después de enviar el mensaje
                NombreUsuario = string.Empty;
                MensajeUsuario = string.Empty;
            }
        }

        public bool enviarCanExecute()
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
