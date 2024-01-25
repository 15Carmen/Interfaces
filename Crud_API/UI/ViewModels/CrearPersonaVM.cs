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

        ObservableCollection<clsDepartamento> listaDepartamentos = new ObservableCollection<clsDepartamento>();
        clsDepartamento departamentoSeleccionado;
        clsPersona nuevaPersona;
        DelegateCommand cancelarCommand;
        DelegateCommand guardarCommand;

        #endregion

        #region constructores

        public CrearPersonaVM()
        {
            //cargamos la lista de los departamentos
            CargarLista();
            this.nuevaPersona = new clsPersona();
            this.departamentoSeleccionado = new clsDepartamento();
            guardarCommand = new DelegateCommand(GuardarCommand_Execute);
            cancelarCommand = new DelegateCommand(CancelarCommadn_Execute, CancelarCommand_CanExecute);

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

        public ObservableCollection<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }

        public clsPersona NuevaPersona
        {
            get { return nuevaPersona; }
            set
            {
                nuevaPersona = value;

                NotifyPropertyChanged(nameof(NuevaPersona));
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
            }
        }

        #endregion

        #region commands

        private async void GuardarCommand_Execute()
        {
            //Manda la persona a la bbdd.
            await clsHandlerPersonasBL.insertarPersonasBL(nuevaPersona);

            //Esto navegará al listado de personas.
            await Shell.Current.Navigation.PushAsync(new ListadoPersonasPage());
        }

        private bool CancelarCommand_CanExecute()
        {
            bool puedeCancelar = false;

            if (nuevaPersona != null)
            {
                puedeCancelar = true;

            }

            return puedeCancelar;
        }

        /// <summary>
        /// Método que cancela la inserción de una persona.
        /// </summary>
        private async void CancelarCommadn_Execute()
        {
            //Esto navegará al listado de personas.
            await Shell.Current.Navigation.PopAsync();
        }

        #endregion

        #region metodos

        private async void CargarLista()
        {
            //Nos traemos la lista de departamentos.
            listaDepartamentos = new ObservableCollection<clsDepartamento>(await clsListadoDepartamentosBL.listadoCompletoDepartamentosBL());

            //Notificamos que ha habido cambios en la propiedad ListaPersonas, para que la cargue la vista.
            NotifyPropertyChanged(nameof(listaDepartamentos));
        }

        #endregion

    }
}
