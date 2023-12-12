using BL.ListadosBL;
using Entidades;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Ejercicio1.ViewModels
{
    public class MainPageVM 
    {
        #region atributos
        private ObservableCollection<clsPersona> listadoCompletoPersonas;
        private List<clsPersona> listaPersonas;

        #endregion

        #region constructores
        public MainPageVM()
        {
            cargarPersonas();
        }

        #endregion

        #region propiedades
        public ObservableCollection<clsPersona> ListadoCompletoPersonas
        {
            get { return listadoCompletoPersonas; }
        }
        #endregion

        #region funciones y metodos

        /// <summary>
        /// Función que llama a la BL y llama al listado de las personas 
        /// </summary>
        /// <returns></returns>
        private async Task cargarPersonas()
        {
            listaPersonas = await clsListadoPersonasBL.listadoCompletoPersonasBL();
            listadoCompletoPersonas = new ObservableCollection<clsPersona>(listaPersonas);

        }

        #endregion
    }
}
