using DAL.Listados;
using Entities;
using System.Collections.ObjectModel;


namespace BL.Listados
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Precondiciones: No tiene.
        /// Conecto con la DAL y, según la lógica del negocio, saco una lista de personas de la base de datos.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve de la DAL un listado de personas.
        /// </summary>
        /// <returns>List de personas.</returns>
        public async static Task<ObservableCollection<clsPersona>> getListadoPersonasBL()
        {
            return new ObservableCollection<clsPersona>(await clsListadoPersonasDAL.getListadoPersonasDAL());
        }
        /// <summary>
        /// Precondiciones: Debe recivir el id de una persona.
        /// Conecto con la DAL y, según la lógica del negocio, le paso el id de la persona que quiero que busque en la base de datos.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve de la DAL una persona.
        /// </summary>
        /// <param name="Id">Entero que representa el id de la persona a buscar.</param>
        /// <returns>Devuelve una clsPersona encontrada por su id.</returns>
        public async static Task<clsPersona> obtenerPersonaPorIdBL(int Id)
        {
            return await clsListadoPersonasDAL.obtenerPersonaPorIdDAL(Id);
        }
    }
}
