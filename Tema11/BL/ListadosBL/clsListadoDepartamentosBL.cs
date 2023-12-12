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
    public class clsListadoDepartamentosBL
    {

        public static async Task<List<clsDepartamento>> listadoCompletoDepartamentosBL()
        {
            return await clsListadoDepartamentosDAL.listadoCompletoDepartamentosDAL();
        }

        public static async Task<clsDepartamento> obtenerDepartamentoPorIdBL(int id)
        {
            return await clsListadoDepartamentosDAL.obtenerDepartamentoPorIdDAL(id);
        }

    }
}
