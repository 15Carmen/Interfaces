using BL.HandlersBL;
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
    public class EditarDepartamentoVM : clsVMBase
    {

        #region atributos

        clsDepartamento departamento;
        DelegateCommand guardarCommand;
        DelegateCommand cancelarCommand;
        

        #endregion

        #region constructores

        public EditarDepartamentoVM()
        {
            guardarCommand = new DelegateCommand(GuardarCommand_Execute, GuardarCommand_CanExecute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute);
        }

        public EditarDepartamentoVM(clsDepartamento departamento)
        {
            this.departamento = departamento;
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
        public clsDepartamento Departamento
        {
            get { return departamento; }
            set
            {
                departamento = value;
                NotifyPropertyChanged(nameof(Departamento));
                cancelarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
            }
        }


        #endregion

        #region commands

        private async void GuardarCommand_Execute()
        {

            //Manda el departamento a la bbdd
            await clsHandlerDepartamentosBL.editarDepartamentoBL(departamento);

            //Esto navegará al listado
            await Shell.Current.Navigation.PushAsync(new ListadoDepartamentosPage());

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

            if (departamento != null)
            {
                puedeGuardar = true;

            }

            return puedeGuardar;
        }

        #endregion

        #region funciones y métodos

        #endregion

    }
}

