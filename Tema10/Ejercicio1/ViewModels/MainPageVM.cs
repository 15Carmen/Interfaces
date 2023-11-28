using Ejercicio1.Models.DAL;
using Ejercicio1.Models.Entidades;
using Ejercicio1.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.ViewModels
{
    internal class MainPageVM : clsVMBase
    {
        #region Atributos

        private DelegateCommand buscarCommand;
        private DelegateCommand eliminarCommand;
        private ObservableCollection<clsPersona> listadoPersonas;
        private String textoBusqueda;
        private clsPersona personaSeleccionada;
        #endregion

        #region Constructores
        public MainPageVM()
        { 
            listadoPersonas = new ObservableCollection<clsPersona>(clsListadoPersonasDAL.listadoCompletoPersonasDAL());
            buscarCommand = new DelegateCommand(buscarCommandExecute, buscarCommandCanExecute);
            eliminarCommand = new DelegateCommand(eliminarCommandExecute, eliminarCommandCanExecute);
               
        }

       #endregion


        #region Propiedades

        public DelegateCommand BuscarCommand
        {
            get { return buscarCommand; }
        }

        public DelegateCommand EliminarCommand
        {
            get { return eliminarCommand; }
        }

        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get { return listadoPersonas; }
        }

        public clsPersona PersonaSeleccionada
        {
            set {  personaSeleccionada = value;}
        }

        public String TextoBusqueda
        {
            get { return textoBusqueda;}
            set { textoBusqueda = value;}
        }

        #endregion

        #region Comandos

        /// <summary>
        /// Método asociado al 
        /// </summary>
        /// <returns>bool habilitado</returns>
        private bool eliminarCommandCanExecute()
        {
            bool habilitadoEliminar = false;

            if(personaSeleccionada != null)
            {
                habilitadoEliminar = true;
            }

            return habilitadoEliminar;

        }

        private void eliminarCommandExecute()
        {

            listadoPersonas.Remove(personaSeleccionada);
            NotifyPropertyChanged("ListadoPersonas");
        }

        private bool buscarCommandCanExecute()
        {
            bool habilitadoBuscar = false;

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                habilitadoBuscar |= true;
            }
            return habilitadoBuscar;
        }

        private void buscarCommandExecute()
        {

            

        }

        #endregion

        #region Metodos y Funciones

        #endregion

    }
}
