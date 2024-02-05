using BL.HandlersBL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewModels.Utilidades;
using UI.Views;

namespace UI.ViewModels
{
    public class CrearDepartamentoVM : clsVMBase
    {

        #region atributos

        clsDepartamento departamentoNuevo;
        DelegateCommand cancelarCommand;
        DelegateCommand guardarCommand;

        #endregion

        #region constructores


        public CrearDepartamentoVM()
        {
            this.departamentoNuevo = new clsDepartamento();
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

        public clsDepartamento DepartamentoNuevo
        {
            get { return departamentoNuevo; }
            set
            {
                departamentoNuevo = value;

                NotifyPropertyChanged(nameof(DepartamentoNuevo));
                cancelarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();

            }
        }

        #endregion

        #region commands

        private async void GuardarCommand_Execute()
        {

            //Manda el departamento a la bbdd
            await clsHandlerDepartamentosBL.insertarDepartamentoBL(departamentoNuevo);

            //Volvemos al listado de personas
            await Shell.Current.Navigation.PushAsync(new ListadoDepartamentosPage());
        }

        /// <summary>
        /// Comando que decide si la operación de insertar se puede o no guardar
        /// </summary>
        private bool GuardarCommand_CanExecute()
        {
            bool puedeGuardar = false;

            if (departamentoNuevo != null)
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

        #endregion

    }
}
