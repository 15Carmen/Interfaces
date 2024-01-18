using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class clsMensajeUsuario
    {
        #region atributos

        private string nombreUsuario;
        private string mensajeUsuario;

        #endregion

        #region constructores

        public clsMensajeUsuario(string nombreUsuario, string mensajeUsuario) 
        {
            this.nombreUsuario = nombreUsuario;
            this.mensajeUsuario = mensajeUsuario;        
        }

        #endregion


        #region propiedades

        [JsonPropertyName ("NombreUsuario")]
        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        [JsonPropertyName("MensajeUsuario")]
        public String MensajeUsuario
        {
            get { return mensajeUsuario; }
            set { mensajeUsuario = value; }
        }

        #endregion

    }
}
