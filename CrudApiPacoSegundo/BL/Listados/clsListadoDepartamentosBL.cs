using DAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listados
{
    public class clsListadoDepartamentosBL
    {
        /// <summary>
        /// Precondiciones: No tiene.
        /// Conecto con la DAL y, según la lógica del negocio, le pido una lista de departamentos.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve una lista de departamentos de la DAL.
        /// </summary>
        /// <returns>List de departamentos.</returns>
        public static async Task<ObservableCollection<clsDepartamentos>> getListadoDepartamentosBL()
        {
            return new ObservableCollection<clsDepartamentos>(await clsListadoDepartamentosDAL.getListadoDepartamentosDAL());
        }
        /// <summary>
        /// Precondiciones: Debe recivbir el id de un departamento.
        /// Conecto con la DAL y, según la lógica del negocio, le pido un departamento por su id.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve un departamento de la DAL.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Devuelvo un clsDepartamento si lo hemos encontrado.</returns>
        public static async Task<clsDepartamentos> obtenerDepartamentoPorIdBL(int Id)
        {
            return await clsListadoDepartamentosDAL.obtenerDepartamentoPorIdDAL(Id);
        }
    }
}
