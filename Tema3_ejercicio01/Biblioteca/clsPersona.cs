using System;

namespace Biblioteca
{
    public class clsPersona
    {
        #region atributos
        private String nombre;
        private String apellidos;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String Direccion { get; set; }

        public String NombreCompleto
        {
            get { return nombre + " " + apellidos; }
        }
        #endregion

        #region funciones y metodos
        /// <summary>
        /// Función que devuelve la concatenación del atributo nombre y del atributo apellido
        /// Precondiciones: 
        /// Postcondiciones: 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <returns></returns>
        public String FuncionNombreCompleto(String nombre, String apellidos)
        {
            return $"Su nombre completo es: {nombre} {apellidos}";
        }
        #endregion
    }
}
