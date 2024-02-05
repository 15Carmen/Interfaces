using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsPersona
    {

        #region Atributos
        private int id;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNac;
        private int idDepartamento;


        #endregion

        #region Constructores

        public clsPersona()
        {
            id = 1;
            nombre = string.Empty;
            apellidos = string.Empty;
            telefono = string.Empty;
            direccion = string.Empty;
            foto = string.Empty;
            fechaNac = DateTime.MinValue;
            idDepartamento = 1;

        }

        public clsPersona(int id, string nombre, string apellidos, string telefono, string direcccion, string foto, DateTime fechaNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direcccion;
            this.foto = foto;
            this.fechaNac = fechaNacimiento;
        }

        public clsPersona(int id, string nombre, string apellidos, string telefono, string direcccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direcccion;
            this.foto = foto;
            this.fechaNac = fechaNacimiento;
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


        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

        #endregion
    }
}
