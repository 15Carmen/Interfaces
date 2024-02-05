using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsDepartamento
    {
        #region atributos

        private int id;
        private string nombre;
        #endregion

        #region constructores

        public clsDepartamento()
        {

            id = 0;
            nombre = string.Empty;
        }

        public clsDepartamento(int idDepartamento, string nombre)
        {
            this.id = idDepartamento;
            this.nombre = nombre;
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

        #endregion



    }
}
