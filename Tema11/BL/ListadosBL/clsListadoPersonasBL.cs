using DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ListadosBL
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Función que llama a la DAL para obtener el listado de personas aplicando las reglas de 
        /// negocio necesarias
        /// </summary>
        /// <returns>Listado completo de personas DAL</returns>
        public static async Task<List<clsPersona>> listadoCompletoPersonasBL()
        {
            return await clsListadoPersonasDAL.listadoCompletoPersonasDAL();
        }

        
        public static async Task<clsPersona> obtenerPersonaPorIdBL(int id)
        {
            return await clsListadoPersonasDAL.obtenerPersonaPorIdDAL(id);
        }
        
    }
}
