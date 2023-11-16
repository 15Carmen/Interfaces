using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biblioteca
{
    public class clsPersona 
    {
        #region Atributos
        private string nombre;
        #endregion

        #region Constructores

        public clsPersona()
        {
            nombre = "Carmen";
        }
        public clsPersona(string nombre)
        {
            this.nombre = nombre;
        }

        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion
    }
}