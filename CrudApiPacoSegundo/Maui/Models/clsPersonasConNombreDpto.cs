using Entities;

namespace Maui.Models
{
    /// <summary>
    /// Clase persona con el nombre de departamento para poder mostrarlo en la vista de personas.
    /// </summary>
    public class clsPersonasConNombreDpto : clsPersona
    {
        #region Atributos
        private string nombreDpto;
        #endregion

        #region Propiedades
        public string NombreDpto { get { return nombreDpto; } set { nombreDpto = value; } }
        #endregion

        #region Constructor
        public clsPersonasConNombreDpto() { }
        public clsPersonasConNombreDpto(string nombreDpto)
        {
            this.nombreDpto = nombreDpto;
        }
        #endregion
    }
}
