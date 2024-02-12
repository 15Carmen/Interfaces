using System.Collections.Generic;
using System.Collections.ObjectModel;
using MauiDAL;
using Entidades;

namespace MauiBL
{
    public class clsHandlerPersonasBL
    {
        /// <summary>
        /// Función que conecta con la DAL y, según la lógica del negocio, saca una lista de personas de la base de datos.
        /// Lanza los errores a la capa superior.
        /// Pre: No tiene
        /// Post: Devuelve de la DAL un listado de personas
        /// </summary>
        /// <returns>List de personas.</returns>
        public async static Task<ObservableCollection<clsPersona>> getListadoCompletoPersonasBL()
        {
            return new ObservableCollection<clsPersona>(await clsHandlerPersonasDAL.getListadoCompletoPersonasDAL());
        }

        /// <summary>
        /// Función que conecta con la DAL y, según la lógica del negocio, le paso el id de la persona que quiero que 
        /// busque en la base de datos.
        /// Lanza los errores a la capa superior.
        /// Pre: Debe recivir el id de una persona.
        /// Post: Devuelve de la DAL una persona.
        /// </summary>
        /// <param name="Id">Entero que representa el id de la persona a buscar.</param>
        /// <returns>Devuelve una clsPersona encontrada por su id.</returns>
        public async static Task<clsPersona> getPersonaPorIdBL(int Id)
        {
            return await clsHandlerPersonasDAL.getPersonaPorIdDAL(Id);
        }

    }
}
