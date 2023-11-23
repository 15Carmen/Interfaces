using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models.Entidades
{
    public class clsPersona
    {

        #region Atributos
        private int id;
        private string nombre;
        private string apellido;
        private int idDepartamento;
        

        #endregion

        #region Constructores

        public clsPersona()
        {
            id = 1;
            nombre = string.Empty;
            apellido = string.Empty;
            idDepartamento = 1;
           
        }
        public clsPersona(int id, string nombre, string apellido, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.idDepartamento = idDepartamento;
          
        }

        #endregion

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value;}
        }

        #endregion
    }
}

