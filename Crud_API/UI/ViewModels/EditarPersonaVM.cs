using BL.HandlersBL;
using Entidades;
using System;
using System.Collections.Generic;
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

        clsPersonaConNombreDepartamento persona;
        DelegateCommand guardarCommand;
        DelegateCommand cancelarCommand;

        #endregion

        #region constructores

        public EditarPersonaVM()
        {
            guardarCommand = new DelegateCommand(GuardarCommand_Execute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute, CancelarCommand_CanExecute);
        }

        public EditarPersonaVM(clsPersonaConNombreDepartamento persona)
        {
            this.persona = persona;
            guardarCommand = new DelegateCommand(GuardarCommand_Execute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute, CancelarCommand_CanExecute);
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
        public clsPersonaConNombreDepartamento Persona
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

        #endregion

        #region commands

        private async void GuardarCommand_Execute()
        {
            clsPersona p = new clsPersona();

            p.Nombre = persona.Nombre;
            p.Apellido = persona.Apellido;
            p.Id = persona.Id;
            p.Direccion = persona.Direccion;
            p.FechaNacimiento = persona.FechaNacimiento;
            p.Foto = persona.Foto;
            p.IdDepartamento = persona.IdDepartamento;

            //Manda la persona a la bbdd.
            await clsHandlerPersonasBL.editarPersonasBL(p);

            //Esto navegará al listado.
            await Shell.Current.Navigation.PushAsync(new ListadoPersonasPage()); 

        }

        /// <summary>
        /// Método que cancela la inserción de una persona.
        /// </summary>
        private async void CancelarCommand_Execute()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private bool CancelarCommand_CanExecute()
        {
            bool puedeCancelar = false;

            if (persona != Persona)
            {
                puedeCancelar = true;

            }

            return puedeCancelar;
        }

        #endregion

    }
}
