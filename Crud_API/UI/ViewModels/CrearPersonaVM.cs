using BL.HandlersBL;
using BL.ListadosBL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewModels.Utilidades;
using UI.Views;

namespace UI.ViewModels
{
    public class CrearPersonaVM : clsVMBase
    {

        #region atributos

        clsPersona personaNueva;
        DelegateCommand cancelarCommand;
        DelegateCommand guardarCommand;
        ObservableCollection<clsDepartamento> desplegableDepartamentos = new ObservableCollection<clsDepartamento>();
        clsDepartamento departamentoSeleccionado;

        #endregion

        #region constructores


        public CrearPersonaVM()
        {
            CargarDesplegable();
            this.personaNueva = new clsPersona();        
            this.departamentoSeleccionado = null;
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

        public ObservableCollection<clsDepartamento> DesplegableDepartamentos
        {
            get { return desplegableDepartamentos; }
            
        }

        public clsPersona PersonaNueva
        {
            get { return personaNueva; }
            set
            {
                personaNueva = value;

                NotifyPropertyChanged(nameof(PersonaNueva));
                cancelarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();

            }
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

            personaNueva.IdDepartamento = departamentoSeleccionado.Id;

            //Manda la persona a la bbdd
            await clsHandlerPersonasBL.insertarPersonasBL(personaNueva);

            //Volvemos al listado de personas
            await Shell.Current.Navigation.PushAsync(new ListadoPersonasPage());
        }

        /// <summary>
        /// Comando que decide si la operación de insertar se puede o no guardar
        /// </summary>
        private bool GuardarCommand_CanExecute()
        {
            bool puedeGuardar = false;

            if (personaNueva != null)
            {
                puedeGuardar = true;

            }

            return puedeGuardar;
        }



        /// <summary>
        /// Comando que cancela la inserción de una persona
        /// </summary>
        private async void CancelarCommand_Execute()
        {
            //Volvemos al listado de personas
            await Shell.Current.Navigation.PopAsync();
        }

        #endregion

        #region metodos


        /// <summary>
        /// Método que guarda en la variable DesplegableDepartamentos el listado de departamentos que sacamos de la api
        /// </summary>
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
