using DAL.Handlers;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.HandlersBL
{
    public class clsHandlerDepartamentosBL
    {
        public static async Task<HttpStatusCode> insertarDepartamentoBL(clsPersona departamento)
        {
            return await clsHandlerDepartamentosDAL.insertarDepartamentoDAL(departamento);
        }

        public static async Task<HttpStatusCode> editarDepartamentoBL(clsPersona departamento)
        {
            return await clsHandlerDepartamentosDAL.editarDepartamentoDAL(departamento);
        }

        public static async Task<HttpStatusCode> borrarDepartamentoBL(int id)
        {
            return await clsHandlerDepartamentosDAL.borrarDepartamentoDAL(id);
        }

    }
}
