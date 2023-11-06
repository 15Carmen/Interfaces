using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio5_ListView.Entidades
{
    class clsPersona
    {

        #region atributos
        private string nombre;
        private string apellidos;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona(string nombre, string apellidos)
        {
            Nombre = nombre;
            Apellidos = apellidos;   
        }

        #endregion

        #region propiedades
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellidos}"; }
        }
        #endregion
    }
}

