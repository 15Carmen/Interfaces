using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema8_PlacasSolares.Modelo.Entidades
{
    class clsCitas
    {

        #region atributos
        private string direccion;
        private string nombreCliente;
        private long tlf;
        private Boolean visitado;

        #endregion

        #region constructores

        public clsCitas() {
            direccion = "";
            nombreCliente = "";
            tlf = 0;
            visitado = false;
        }

        public clsCitas(string direccion, string nombreCliente, long tlf, bool visitado)
        {
            this.direccion = direccion;
            this.nombreCliente = nombreCliente;
            this.tlf = tlf;
            this.visitado = visitado;
        }

        #endregion

        #region propiedades

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value;}
        }

        public long Tlf
        {
            get { return tlf; }
            set { tlf = value; }
        }

        public Boolean Visitado
        {
            get { return visitado; }
            set { visitado = value; }
        }

        #endregion
    }
}
