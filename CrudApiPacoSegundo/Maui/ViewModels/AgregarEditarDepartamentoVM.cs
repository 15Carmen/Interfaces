using BL.Manejadoras;
using Entities;
using Maui.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.ViewModels
{
    /// <summary>
    /// ViewModel para editar o crear departamentos.
    /// </summary>
    [QueryProperty("Departamento", "departamentoParaMandar")]
    public class AgregarEditarDepartamentoVM : clsVMBase
    {
        #region Atributos
        private DelegateCommand agregarCommand;
        private DelegateCommand editarCommand;
        private clsDepartamentos departamento;
        #endregion

        #region Contructores
        public AgregarEditarDepartamentoVM()
        {
            agregarCommand = new DelegateCommand(AgregarCommand_Executed);
            editarCommand = new DelegateCommand(EditarCommand_Executed);
            Departamento = new clsDepartamentos();
        }
        #endregion

        #region Propiedades
        public clsDepartamentos Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
        public DelegateCommand AgregarCommand { get { return agregarCommand; } }
        public DelegateCommand EditarCommand { get { return editarCommand; } }
        #endregion

        #region Commands
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para agregar el departamento.
        /// Postcondiciones: Agregas el departamento en la BBDD.
        /// </summary>
        private async void AgregarCommand_Executed()
        {
            bool agregar = await Application.Current.MainPage.DisplayAlert("¿Agregar departamento?", null, "Si", "No");
            if (agregar)
            {
                try
                {
                    await clsManejadoraDepartamentos.insertarDepartamentoBL(Departamento);
                    await Application.Current.MainPage.DisplayAlert("Departamento insertado correctamente", null, "Ok");
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert!", "No se ha podido insertar el departamento", "Ok");
                }
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para editar a la persona.
        /// Postcondiciones: Editas el departamento en la BBDD.
        /// </summary>
        private async void EditarCommand_Executed()
        {
            bool agregar = await Application.Current.MainPage.DisplayAlert("¿Editar departamento?", null, "Si", "No");
            if (agregar)
            {
                try
                {
                    await clsManejadoraDepartamentos.editarDepartamentoBL(Departamento);
                    await Application.Current.MainPage.DisplayAlert("Departamento editado correctamente", null, "Ok");
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert!", "No se ha podido editar el departamento", "Ok");
                }
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        #endregion
    }
}
