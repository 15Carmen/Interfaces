using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Handlers;

namespace BL.HandlersBL
{
    public class clsHandlerPersonasBL
    {
        public static async Task<HttpStatusCode> insertarPersonasBL(clsPersona persona)
        {
            return await clsHandlerPersonasDAL.insertarPersonaDAL(persona);
        }

        public static async Task<HttpStatusCode> editarPersonasBL(clsPersona persona)
        {
            return await clsHandlerPersonasDAL.editarPersonaDAL(persona);
        }

        public static async Task<HttpStatusCode> borrarPersonasBL(int id)
        {
            return await clsHandlerPersonasDAL.borrarPersonaDAL(id);
        }

    }
}
