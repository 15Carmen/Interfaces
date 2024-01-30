using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsPersona
    {
        #region Atributos
        private int _id;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;
        private string _foto;
        private DateTime _fechaNacimiento;
        private int _idDepartamento;
        #endregion

        #region Propiedades
        public int id { get { return _id; } set { _id = value; } }
        [Required]
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public string telefono { get { return _telefono; } set { _telefono = value; } }
        public string direccion { get { return _direccion; } set { _direccion = value; } }
        public string foto { get { return _foto; } set { _foto = value; } }
        public DateTime fechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }
        public int idDepartamento { get { return _idDepartamento; } set { _idDepartamento = value; } }
        #endregion

        #region Constructores
        public clsPersona() { }
        public clsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _telefono = telefono;
            _direccion = direccion;
            _foto = foto;
            _fechaNacimiento = fechaNacimiento;
            _idDepartamento = idDepartamento;
        }
        public clsPersona(string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            _nombre = nombre;
            _apellidos = apellidos;
            _telefono = telefono;
            _direccion = direccion;
            _foto = foto;
            _fechaNacimiento = fechaNacimiento;
            _idDepartamento = idDepartamento;
        }
        #endregion
    }
}
