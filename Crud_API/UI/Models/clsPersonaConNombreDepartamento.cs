using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class clsPersonaConNombreDepartamento : clsPersona
    {
        #region atributos
        private string nombreDepartamento;

        #endregion

        #region constructores
        public clsPersonaConNombreDepartamento()
        { }

        public clsPersonaConNombreDepartamento(string nombreDepartamento)
        {
            this.nombreDepartamento = nombreDepartamento;
        }

        public clsPersonaConNombreDepartamento(clsPersona p)
        {
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.Direccion = p.Direccion;
            this.FechaNac = p.FechaNac;
            this.Foto = p.Foto;
            this.Id = p.Id;
            this.IdDepartamento = p.IdDepartamento;
            this.Telefono = p.Telefono;
            nombreDepartamento = "";
        }

        #endregion

        #region propiedades
        public string NombreDepartamento
        {
            get { return nombreDepartamento; }
            set { nombreDepartamento = value; }
        }


        #endregion


    }
}
