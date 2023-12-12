using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    public class clsPersonaConNombreDepartamento : clsPersona
    {

        #region Atributos
        private string nombreDpto;
        #endregion

        #region Constructor
        public clsPersonaConNombreDepartamento() { }
        public clsPersonaConNombreDepartamento(clsPersona persona, string nombreDpto)
        {
            //Indicamos que las propiedades heredadas de esta clase son iguales a las pasadas por parámetro
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellido = persona.Apellido;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdDepartamento = persona.IdDepartamento;
            this.nombreDpto = nombreDpto;
        }
        #endregion

        #region Propiedades
        public string NombreDpto { 
            get { return nombreDpto; }
            set { nombreDpto = value; } 
        }
        #endregion

    }
}
