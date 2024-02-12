using Entidades;
using MauiDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBL
{
    public class clsHandlerDepartamentosBL
    {
        /// <summary>
        /// Función que conecta con la DAL y, según la lógica del negocio, le pide una lista de departamentos.
        /// Lanza los errores a la capa superior.
        /// Pre: No tiene.
        /// Post: Devuelve una lista de departamentos de la DAL.
        /// </summary>
        /// <returns>List de departamentos</returns>
        public static async Task<ObservableCollection<clsDepartamento>> getListadoCompletoDepartamentosBL()
        {
            return new ObservableCollection<clsDepartamento>(await clsHandlerDepartamentosDAL.getListadoCompletoDepartamentosDAL());
        }
        /// <summary>
        /// Función que conecta con la DAL y, según la lógica del negocio, le pide un departamento por su id.
        /// Lanza los errores a la capa superior.
        /// Pre: Debe recivbir el id de un departamento.
        /// Post: Devuelve un departamento de la DAL.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Devuelvo un clsDepartamento si lo hemos encontrado</returns>
        public static async Task<clsDepartamento> getDepartamentoPorIdBL(int Id)
        {
            return await clsHandlerDepartamentosDAL.getDepartamentoPorIdDAL(Id);
        }
    }
}

