using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsConexion
    {
        /// <summary>
        /// Función que devuelve la cadena de la URI base de mi API
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>El enlace a la URI base</returns>
        public static string conexionApi()
        {
            return "https://crudnervion.azurewebsites.net/api/";
        }
    }
}
