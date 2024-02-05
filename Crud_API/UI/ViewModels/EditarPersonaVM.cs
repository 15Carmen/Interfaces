using BL.HandlersBL;
using BL.ListadosBL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using UI.ViewModels.Utilidades;
using UI.Views;

namespace UI.ViewModels
{
    public class EditarPersonaVM : clsVMBase
    {

        #region atributos

        clsPersona persona;
        DelegateCommand guardarCommand;
        DelegateCommand cancelarCommand;
        ObservableCollection<clsDepartamento> desplegableDepartamentos;
        clsDepartamento departamentoSeleccionado;

        #endregion

        #region constructores

        public EditarPersonaVM()
        {
            guardarCommand = new DelegateCommand(GuardarCommand_Execute, GuardarCommand_CanExecute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute);
        }

        public EditarPersonaVM(clsPersona persona)
        {
            CargarDesplegable();
            this.persona = persona;
            desplegableDepartamentos = new ObservableCollection<clsDepartamento>();
            departamentoSeleccionado = null;
            guardarCommand = new DelegateCommand(GuardarCommand_Execute, GuardarCommand_CanExecute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute);
        }

        #endregion

        #region propiedades

        public DelegateCommand GuardarCommand
        {
            get { return guardarCommand; }
        }

        public DelegateCommand CancelarCommand
        {
            get { return cancelarCommand; }

        }
        public clsPersona Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                NotifyPropertyChanged(nameof(Persona));
                cancelarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<clsDepartamento> DesplegableDepartamentos
        {
            get { return desplegableDepartamentos; }            
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged(nameof(DepartamentoSeleccionado));
                cancelarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region commands

        private async void GuardarCommand_Execute()
        {
            
            persona.IdDepartamento = departamentoSeleccionado.Id;

            //Manda la persona a la bbdd
            await clsHandlerPersonasBL.editarPersonasBL(persona);

            //Esto navegará al listado
            await Shell.Current.Navigation.PushAsync(new ListadoPersonasPage()); 

        }

        /// <summary>
        /// Método que cancela la edición de una persona.
        /// </summary>
        private async void CancelarCommand_Execute()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        /// <summary>
        /// Comando que decide si la operación de insertar se puede o no guardar
        /// </summary>
        private bool GuardarCommand_CanExecute()
        {
            bool puedeGuardar = false;

            if (persona != null)
            {
                puedeGuardar = true;

            }

            return puedeGuardar;
        }

        #endregion

        #region funciones y métodos

        private async void CargarDesplegable()
        {
            //Guardamos en una lista los departamentos que sacamos de la api
            desplegableDepartamentos = new ObservableCollection<clsDepartamento>(await clsListadoDepartamentosBL.listadoCompletoDepartamentosBL());

            //Notificamos que ha habido cambios en la propiedad DesplegableDepartamentos
            NotifyPropertyChanged(nameof(DesplegableDepartamentos));
        }

        #endregion

    }
}
