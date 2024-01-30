using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsDepartamentos
    {
        #region Atributos
        private int _id;
        private string _nombre;
        #endregion

        #region Propiedades
        public int id { get { return _id; } set { _id = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        #endregion

        #region Constructores
        public clsDepartamentos() { }
        public clsDepartamentos(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
        public clsDepartamentos(string nombre)
        {
            _nombre = nombre;
        }
        #endregion
    }
}
