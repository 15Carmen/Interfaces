using Entities;
using DAL.Manejadoras;
using System.Net;

namespace BL.Manejadoras
{
    public class clsManejadoraDepartamentos
    {
        /// <summary>
        /// Precondiciones: Deber recivir la id de un departamento.
        /// Recibe un entero que es el id del departamento a eliminar y, según la lógica del negocio, accede a la DAL para eliminarlo.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Llama a la DAL para borrar un departamento.
        /// </summary>
        /// <param name="id">Entero que representa el id del departamento a eliminar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static async Task<HttpStatusCode> borrarDepartamentosBL(int id)
        {
            return await clsManejadoraDepartamentosDAL.borrarDepartamentosDAL(id);
        }

        /// <summary>
        /// Precondiciones: Deber recivir la id de un departamento.
        /// Recibe un departamento ya editado y, según la lógica del negocio, lo manda a la DAL para actualizarlo.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Llama a la DAL para editar un departamento.
        /// </summary>
        /// <param name="departamento">Departamento para editar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static async Task<HttpStatusCode> editarDepartamentoBL(clsDepartamentos departamento)
        {
            return await clsManejadoraDepartamentosDAL.editarDepartamentoDAL(departamento);
        }

        /// <summary>
        /// Precondiciones: Debe recivir un departamento relleno.
        /// Recibe un departamentos ya relleno y, según la lógica del negocio, lo manda a la DAL para insertarlo.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Llama a la DAL para insertar un nuevo departamento.
        /// </summary>
        /// <param name="persona">Departamento para insertar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static async Task<HttpStatusCode> insertarDepartamentoBL(clsDepartamentos departamento)
        {
            return await clsManejadoraDepartamentosDAL.insertarDepartamentoDAL(departamento);
        }
    }
}
