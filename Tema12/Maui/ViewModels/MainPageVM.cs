using Ejercicio1.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Collections.ObjectModel;

namespace Maui.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        #region atributos

        private clsMensajeUsuario oMensajeUsuario;
        private string nombreUsuario;
        private string mensajeUsuario;
        private DelegateCommand btnEnviarMensaje;
        private ObservableCollection<clsMensajeUsuario> listaChats;

        #endregion

        #region constructores

        public MainPageVM()
        {
            listaChats = new ObservableCollection<clsMensajeUsuario>();
            btnEnviarMensaje = new DelegateCommand(enviarExecute, enviarCanExecute);
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

        #endregion

        #region commands

        public void enviarExecute()
        {
            //TODO: comando enviar mensaje
        }

        public bool enviarCanExecute()
        {
            bool enviar = false;

            if(!string.IsNullOrEmpty(NombreUsuario) || !string.IsNullOrEmpty(MensajeUsuario))
            {
                enviar = true;
            }

            return enviar;
        }



        #endregion

    }
}
